using System;
using System.Collections.Generic;
using System.Linq;
using Katas.Models;

namespace Katas
{
    public class KatasClass
    {
        // takes a collection of strings, checks each string for any mentions + hashtags, returns a dictionary of found mentions + hashtags with their counts

        public Dictionary<string, int> TwitterFeedAnalysis(IEnumerable<string> twitterFeed)
        {
            var feed = twitterFeed.ToList();
            var tally = new Dictionary<string, int>();

            foreach (var tweet in feed)
            {
                var words = tweet.Split(' ');
                foreach (var word in words)
                {
                    var firstChar = word.Substring(0, 1);

                    if (firstChar == "@" || firstChar == "#")
                    {
                        tally[word] = !tally.TryGetValue(word, out int i) ? 1 : i + 1;

                    } 
                }
            }

            return tally;
        }

        // takes a collection of users and a collection of up-to-date notes, returns a list of users with their notes updated

        public List<User> UpdateUserNotes(IEnumerable<User> users, IEnumerable<Note> notes)
        {
            var usersAsAList = new List<User>(users);

            if (usersAsAList.Count == 0) return new List<User>();
            foreach (User user in usersAsAList) {
                 foreach (Note note in notes)
                 {
                    var targetNote = user.Notes.Find(userNote => userNote.Id == note.Id);
                    if (targetNote != null)
                    {
                        note.Value = targetNote.Value;
                    }
                }
            }
            return usersAsAList;
        }

        // takes a collection of customers and a collection of guids, returns a dictionary of categorized customer ids
        // deprecated: are non-Guid ids
        // current: customer ids that exist in the currentGuids collection
        // legacy: customer ids that aren't in the currentGuids collection

        public Dictionary<string, List<string>> GetDictionary(IEnumerable<Customer> customers, IEnumerable<Guid> currentGuids)
        {
            var dictionary = new Dictionary<string, List<string>>
            {
                { "current", new List<string>() },
                { "legacy", new List<string>() },
                { "deprecated", new List<string>() }

            };

            foreach (Customer customer in customers)
            {
                string state = Guid.TryParse(customer.Id, out Guid guid)
                    ? currentGuids.Contains(guid)
                    ? "current"
                    : "legacy"
                    : "deprecated";

                dictionary[state].Add(customer.Name);
            }

            return dictionary;
        }

        // take a string and make is sassy (alternating lower/upper case)

        public string ConvertToSassCase(string input)
        {
            var output = "";

            for (int i = 0; i < input.Length; i++)
            {
                var character = input[i].ToString();
                var cased = i % 2 == 0
                    ? character.ToUpper()
                    : character.ToLower();

                output += cased;
            }

            return output;
        }

        // take a List of customers, filter out customers who are under 161cm height, return the list

        public List<Customer> CheckHeight(List<Customer> customers)
        {
            return customers.FindAll(customer => customer.HeightCM >= 160);
        }

        // takes a list of artwork submissions and a cutoff date, return the first three to be submitted on time.

        public Artwork[] TriageArtworks(List<Artwork> submissions, DateTime cutoffDate)
        {
            return submissions
                .FindAll(artwork =>artwork.submissionTimestamp < cutoffDate)
                .OrderBy(artwork => artwork.submissionTimestamp)
                .Take(3)
                .ToArray();
        }

        // takes a mixed list of Animals - Dogs and Cats. Return true if most are cats, false if most are dogs, null if equal.

        public bool? AreCatsDominant(List<Animal> animals)
        {
            int i = 0;

            foreach (var animal in animals)
            {
                if (animal is Cat) i++;
                if (animal is Dog) i--;
            }

            if (i > 0) return true;
            if (i < 0) return false;
            return null;
        }
    }
}

