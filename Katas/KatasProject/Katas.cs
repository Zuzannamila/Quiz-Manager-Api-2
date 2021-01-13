using System;
using System.Collections.Generic;
using Katas.Models;

namespace Katas
{
    public class KatasClass
    {
        // takes a collection of strings, checks each string for any mentions + hashtags, returns a dictionary of found mentions + hashtags with their counts

        public Dictionary<string, int> TwitterFeedAnalysis(IEnumerable<string> twitterFeed)
        {
            return new Dictionary<string, int>();
        }

        // takes a collection of users and a collection of up-to-date notes, returns a list of users with their notes updated

        public List<User> UpdateUserNotes(IEnumerable<User> users, IEnumerable<Note> notes)
        {
            return new List<User>();
        }

        // takes a collection of customers and a collection of guids, returns a dictionary of categorized customer ids
        // deprecated: are non-Guid ids
        // current: customer ids that exist in the currentGuids collection
        // legacy: customer ids that aren't in the currentGuids collection

        public Dictionary<string, List<string>> GetDictionary(IEnumerable<Customer> customers, IEnumerable<Guid> currentGuids)
        {
            return new Dictionary<string, List<string>>();
        }

        // take a string and make is sassy (alternating lower/upper case)

        public string ConvertToSassCase(string input)
        {
            return "";
        }

        // take a List of customers, filter out customers who are under 161cm height, return the list

        public List<Customer> CheckHeight(List<Customer> customers)
        {
            return new List<Customer>();
        }

        // takes a list of artwork submissions and a cutoff date, return the first three to be submitted on time.

        public Artwork[] TriageArtworks(List<Artwork> submissions, DateTime cutoffDate)
        {
            return new Artwork[0];
        }

        // takes a mixed list of Animals - Dogs and Cats. Return true if most are cats, false if most are dogs, null if equal.

        public bool? AreCatsDominant(List<Animal> animals)
        {
            return true;
        }
    }
}

