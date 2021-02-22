import pyodbc
import os
from urllib import request
from urllib.error import URLError, HTTPError
import logging


#define the server name and the database name


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

def push_to_churnzero(url) :
    #request it
    try:
        resp = request.urlopen(url)
    except HTTPError as e:
    #401 means wrong api key, handle it
        logging.info('Error code: ' + str(e.code))
    except URLError as e: 
        logging.info('Reason: ' + str(e.reason))

def finish_off(counter) :
    logging.info('Pushed ' + str(counter) + ' events to Churnzero.')
    cursor.close()
    cnxn.close()
    