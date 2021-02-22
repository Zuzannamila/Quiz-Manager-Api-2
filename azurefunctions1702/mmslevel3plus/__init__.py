import pyodbc
import urllib
from urllib import parse
import os
import datetime
import logging
import azure.functions as func
import requests

# from shared_code.utils import server, database, uid, pwd, cnxn, cursor, push_to_churnzero, finish_off
# from shared_code.utils import push_to_churnzero, finish_off


def main(mytimer: func.TimerRequest) -> None:
    utc_timestamp = datetime.datetime.utcnow().replace(
        tzinfo=datetime.timezone.utc).isoformat()

    if mytimer.past_due:
        logging.info('The timer is past due!')

    logging.info('Python timer trigger function ran at %s', utc_timestamp)


    for driver in pyodbc.drivers():
        logging.info(driver)

    


    # server = os.environ["dbserver"]
    server = "sw-vis-qa-ukw-1-sqlsvr.database.windows.net"
    # database = os.environ["dbname"]
    database = "sw-vis-qa-ukw-1-sqldb"
    # uid = os.environ["dbuser"]
    # pwd = os.environ["dbpassword"]
    uid = "swadmin"
    pwd="Sm00thwall"

    #define connection
    cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'
        'SERVER=' + server + ';'
        'DATABASE=' + database + ';'
        'PORT=1433;'                   
        'UID=' + uid + ';'
        'PWD=' + pwd + ';')
    #create the connection cursor
    cursor = cnxn.cursor()
    # execute
    cursor.execute('''
        SELECT 
            [timestamp]
            ,[OrgID]
            ,[Level]
        FROM [dbo].[Visigo_Ground_Events]
        WHERE timestamp >= DATEADD(day, -1, GETDATE()) AND level >= 3

    ''')
    #commit 
    #cnxn.commit()



    #adding counter to make sure all is working
    counter = 0
    #creating http api
    for row in cursor:
        counter += 1
        d = row[0].isoformat()
        query1 = 'https://eu1analytics.churnzero.net/i?appKey=1!2wrI-kD2u-7xpvIzCjqP-bObtJ1mxEZYK6NPZdJVZU8tA2C&'
        f = { 'accountExternalId' : row[1], 'contactExternalId': 'MMS ' + row[1], 'action': 'trackEvent', 'eventName' : 'MMS L3+ Event', 'eventDate': d, 'cf_Level' : row[2] }
        correct_url = urllib.parse.urlencode(f)
    
        url = query1 + correct_url
        print(url)
        #request it
        # push_to_churnzero(url)
    
    # finish_off(counter)
print("zuza")

    