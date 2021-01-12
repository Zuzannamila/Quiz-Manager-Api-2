using System;
using System.Collections.Generic;
using Katas;
using Katas.Models;
using Xunit;

namespace Test
{
    public class KatasTestClass 
    {
        public KatasClass _testClass = new KatasClass();
    }

    public class AreCatsDominant : KatasTestClass
    {
        [Fact]
        public void GivenNoAnimals_ReturnsNull()
        {
            // arrange
            var animals = new List<Animal>();

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenOnlyCats_ReturnsTrue()
        {
            // arrange
            var animals = new List<Animal> { new Cat() };

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void GivenOnlyDogs_ReturnsFalse()
        {
            // arrange
            var animals = new List<Animal> { new Dog() };

            // act
            var result = _testClass.AreCatsDominant(animals);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void GivenMixedInput_ReturnsCorrectly()
        {
            // arrange
            var animals1 = new List<Animal> { new Dog(), new Cat(), new Cat() };
            var animals2 = new List<Animal> { new Dog(), new Dog(), new Cat() };
            var animals3 = new List<Animal> { new Dog(), new Dog(), new Cat(), new Cat() };

            // act
            var result1 = _testClass.AreCatsDominant(animals1);
            var result2 = _testClass.AreCatsDominant(animals2);
            var result3 = _testClass.AreCatsDominant(animals3);

            // assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.Null(result3);
        }
    }

    public class TriageArtworks : KatasTestClass
    {
        private readonly Artwork _artwork1 = new Artwork { Desctiption = "a lovely moonscape", Artist = "Haz", submissionTimestamp = DateTime.Parse("2015-06-21") };
        private readonly Artwork _artwork2 = new Artwork { Desctiption = "pig in a blanket", Artist = "Sarah", submissionTimestamp = DateTime.Parse("2018-09-04") };
        private readonly Artwork _artwork3 = new Artwork { Desctiption = "self portrait", Artist = "Tom", submissionTimestamp = DateTime.Parse("2020-11-23") };
        private readonly Artwork _artwork4 = new Artwork { Desctiption = "the meaning of life", Artist = "Sam", submissionTimestamp = DateTime.Parse("2019-02-15") };
        private readonly Artwork _artwork5 = new Artwork { Desctiption = "maths - a colourscape", Artist = "Liam", submissionTimestamp = DateTime.Parse("2020-10-01") };

        [Fact]
        public void GivenEmptyList_ReturnsEmptyList()
        {
            // arrange
            var submissions = new List<Artwork>();

            // act
            var result = _testClass.TriageArtworks(submissions, DateTime.Parse("2020-11-23"));

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void GivenOneSubmissionOutOfDate_ReturnsEmptyList()
        {
            // arrange
            var submissions = new List<Artwork> { _artwork1 };

            // act
            var result = _testClass.TriageArtworks(submissions, DateTime.Parse("2014-11-23"));

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void GivenOneSubmissionInDate_ReturnsSubmission()
        {
            // arrange
            var submissions = new List<Artwork> { _artwork1 };

            // act
            var result = _testClass.TriageArtworks(submissions, DateTime.Parse("2019-02-16"));

            // assert
            Assert.Single(result);
            Assert.Equal(_artwork1.Artist, result[0].Artist);
        }

        [Fact]
        public void GivenAMix_ReturnsThreeEarliestSubmissionsInDate()
        {
            // arrange
            var submissions = new List<Artwork> { _artwork1, _artwork2, _artwork3, _artwork4, _artwork5 };

            // act
            var result = _testClass.TriageArtworks(submissions, DateTime.Parse("2020-10-16"));

            // assert
            Assert.Equal(3, result.Length);
            Assert.Contains(_artwork4, result);
            Assert.Contains(_artwork1, result);
            Assert.Contains(_artwork2, result);
            Assert.Equal(_artwork1, result[0]);

        }
    }

    public class CheckHeight : KatasTestClass
    {
        private readonly Customer _customerOne = new Customer { HeightCM = 200 };
        private readonly Customer _customerTwo = new Customer { HeightCM = 100 };
        private readonly Customer _customerThree = new Customer { HeightCM = 160 };

        [Fact]
        public void GivenEmptyList_ReturnsList()
        {
            // arrange
            var customers = new List<Customer>();

            // act
            var result = _testClass.CheckHeight(customers);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void GivenSingleCustomerList_ReturnsList()
        {
            // arrange
            var customers = new List<Customer>
            {
                _customerOne,
            };

            // act
            var result = _testClass.CheckHeight(customers);

            // assert
            Assert.Single(result);
        }

        [Fact]
        public void GivenMultiCustomerList_ReturnsList()
        {
            // arrange
            var customers = new List<Customer>
            {
                _customerOne,
                _customerTwo,
                _customerThree,
            };

            // act
            var result = _testClass.CheckHeight(customers);

            // assert
            Assert.All(result, customer => Assert.True(customer.HeightCM >= 160));
        }
    }

    public class ConvertToSassCase : KatasTestClass
    {
        [Fact]
        public void GivenEmptyString_ReturnsEmptyString()
        {
            // arrange
            var input = "";

            // act
            var result = _testClass.ConvertToSassCase(input);

            // assert
            Assert.Equal(input, result);
        }

        [Fact]
        public void GivenSingleCharString_ReturnsUpperCase()
        {
            // arrange
            var input = "a";

            // act
            var result = _testClass.ConvertToSassCase(input);

            // assert
            var expectedResult = "A";
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenMultiCharString_ReturnsSassCase()
        {
            // arrange
            var input = "banana";

            // act
            var result = _testClass.ConvertToSassCase(input);

            // assert
            var expectedResult = "BaNaNa";
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenMultiCasedString_ReturnsSassCase()
        {
            // arrange
            var input = "banANA";

            // act
            var result = _testClass.ConvertToSassCase(input);

            // assert
            var expectedResult = "BaNaNa";
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenWeirdString_IgnoresSpecialCharacters()
        {
            // arrange
            var input = "*&^%$£";

            // act
            var result = _testClass.ConvertToSassCase(input);

            // assert
            Assert.Equal(input, result);
        }
    }

    public class TwitterFeedAnalysis : KatasTestClass
    {
        [Fact]
        public void ReturnEmptyDict_WhenGivenEmptyFeed()
        {
            // arrange
            var feed = new List<string>();

            // act
            var result = _testClass.TwitterFeedAnalysis(feed);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnEmptyDict_WhenGivenNoMentionsOrTags()
        {
            // arrange
            var feed = new List<string> { "hello!", "this is a peaceful twitter message"};

            // act
            var result = _testClass.TwitterFeedAnalysis(feed);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void ReturnEmptyDict_WhenGivenMentions()
        {
            // arrange
            var feed = new List<string> { "hello, @Xav", "this is a peaceful @Philippa twitter message", "saw @Philippa on the tube today!" };

            // act
            var result = _testClass.TwitterFeedAnalysis(feed);

            // assert
            Assert.Equal(1, result["@Xav"]);
            Assert.Equal(2, result["@Philippa"]);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ReturnEmptyDict_WhenGivenHashtags()
        {
            // arrange
            var feed = new List<string> { "#cats", "#dogs", "#cats" };

            // act
            var result = _testClass.TwitterFeedAnalysis(feed);

            // assert
            Assert.Equal(2, result["#cats"]);
            Assert.Equal(1, result["#dogs"]);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public void ReturnEmptyDict_WhenGivenAMix()
        {
            // arrange
            var feed = new List<string> { "#cats are the best, says @Vel", "@Hannah loved #dogs @Bethan agrees", "#cats for life" };

            // act
            var result = _testClass.TwitterFeedAnalysis(feed);

            // assert
            Assert.Equal(2, result["#cats"]);
            Assert.Equal(1, result["#dogs"]);
            Assert.Equal(1, result["@Vel"]);
            Assert.Equal(1, result["@Hannah"]);
            Assert.Equal(1, result["@Bethan"]);
            Assert.Equal(5, result.Count);
        }
    }

    public class CreateDictionary : KatasTestClass
    {
        private readonly Guid _currentGuidOne;
        private readonly Guid _currentGuidTwo;
        private readonly Customer _customerOne;
        private readonly Customer _customerTwo;

        public CreateDictionary()
        {
            _currentGuidOne = Guid.NewGuid();
            _currentGuidTwo = Guid.NewGuid();

            _customerOne = new Customer
            {
                Name = "Vel",
                Id = _currentGuidOne.ToString(),
            };

            _customerTwo = new Customer
            {
                Name = "Opal",
                Id = _currentGuidTwo.ToString(),
            };
        }

        [Fact]
        public void ReturnDictionaryWithEmptyLists_WhenGivenEmptyList()
        {
            // arrange
            // act
            var result = _testClass.GetDictionary(new List<Customer>(), new List<Guid>());

            // assert
            Assert.Empty(result["current"]);
            Assert.Empty(result["legacy"]);
            Assert.Empty(result["deprecated"]);
        }

        [Fact]
        public void ReturnsOneCurrentCustomer_WhenGivenCustomerWithIdInCurrentGuids()
        {
            // arrange
            // act
            var result = _testClass.GetDictionary(new List<Customer> { _customerOne }, new List<Guid> { _currentGuidOne });

            // assert
            var currentUsers = result["current"];
            Assert.Single(currentUsers);
            Assert.Equal("Vel", currentUsers[0]);
        }

        [Fact]
        public void ReturnsMutlipleCurrentCustomers_WhenGivenCustomersWithIdsInCurrentGuids()
        {
            // arrange
            var customers = new List<Customer> { _customerOne, _customerTwo };
            var currentGuids = new List<Guid> { _currentGuidOne, _currentGuidTwo };

            // act
            var result = _testClass.GetDictionary(customers, currentGuids);

            // assert
            var currentUsers = result["current"];
            Assert.Equal(2, currentUsers.Count);
            Assert.Equal("Vel", currentUsers[0]);
            Assert.Equal("Opal", currentUsers[1]);
        }

        [Fact]
        public void ReturnsLegacyUsers_WhenGivenNoCurrentGuids()
        {
            // arrange
            var customers = new List<Customer> { _customerOne, _customerTwo };
            var currentGuids = new List<Guid>();

            // act
            var result = _testClass.GetDictionary(customers, currentGuids);

            // assert
            var legacyUsers = result["legacy"];
            Assert.Equal(2, legacyUsers.Count);
            Assert.Equal("Vel", legacyUsers[0]);
            Assert.Equal("Opal", legacyUsers[1]);
        }

        [Fact]
        public void ReturnsDeprecatedUsers_WhenUsersHaveNonParsableIds()
        {
            // arrange
            var deprecatedCustomer = new Customer
            {
                Name = "Xav",
                Id = "banana",
            };

            var customers = new List<Customer> { deprecatedCustomer };
            var currentGuids = new List<Guid>();

            // act
            var result = _testClass.GetDictionary(customers, currentGuids);

            // assert
            var deprecatedUsers = result["deprecated"];
            Assert.Single(deprecatedUsers);
            Assert.Equal("Xav", deprecatedUsers[0]);
        }

        [Fact]
        public void ReturnsSomeCurrentUsers_WhenGivenSomeCurrentGuids()
        {
            // arrange
            var deprecatedCustomer = new Customer
            {
                Name = "Xav",
                Id = "banana",
            };

            var customers = new List<Customer> { _customerOne, _customerTwo, deprecatedCustomer };
            var currentGuids = new List<Guid> { _currentGuidTwo };

            // act
            var result = _testClass.GetDictionary(customers, currentGuids);

            // assert
            var legacyUsers = result["legacy"];
            var currentUsers = result["current"];
            var deprecatedUsers = result["deprecated"];

            Assert.Single(deprecatedUsers);
            Assert.Equal("Xav", deprecatedUsers[0]);

            Assert.Single(legacyUsers);
            Assert.Equal("Vel", legacyUsers[0]);

            Assert.Single(currentUsers);
            Assert.Equal("Opal", currentUsers[0]);
        }
    }

    public class UpdateUserNotes : KatasTestClass
    {
        private readonly User _user = new User { Id = Guid.NewGuid(), Name = "Jim" };
        private readonly User _user2 = new User { Id = Guid.NewGuid(), Name = "David" };
        private readonly Guid _noteGuid1 = Guid.NewGuid();
        private readonly Guid _noteGuid2 = Guid.NewGuid();
        private readonly Note _note1;
        private readonly Note _note2;
        private readonly Note _note3;
        private readonly Note _note4;
        private readonly Note _amendNote1;
        private readonly Note _amendNote2;

        public UpdateUserNotes()
        {
            _note1 = new Note { Id = _noteGuid1, Value = "hello" };
            _amendNote1 = new Note { Id = _noteGuid1, Value = "hellooooooo" };

            _note2 = new Note { Id = _noteGuid2, Value = "bye" };
            _amendNote2 = new Note { Id = _noteGuid2, Value = "BYEEEE~" };

            _note3 = new Note { Id = Guid.NewGuid(), Value = "do not amend me" };
            _note4 = new Note { Id = Guid.NewGuid(), Value = "do not change me either" };
        }

        [Fact]
        public void GivenEmptyUserListReturnsEmptyList()
        {
            // arrange
            var emptyUsers = new List<User>();
            var emptyNotes = new List<Note>();

            // act
            var result = _testClass.UpdateUserNotes(emptyUsers, emptyNotes);

            // assert
            Assert.Empty(result);
        }
        [Fact]
        public void GivenOneUserWithOneNoteUpdateNote()
        {
            // arrange
            _user.Notes = new List<Note> { _note1 };
            var users = new List<User>{ _user };
            var notes = new List<Note> { _amendNote1 };

            // act
            var result = _testClass.UpdateUserNotes(users, notes);

            // assert
            Assert.Equal(result[0].Notes[0].Value, _amendNote1.Value);
            Assert.Equal(result[0].Notes[0].Id, _amendNote1.Id);

        }
        [Fact]
        public void GivenOneUserWithMoreThanOneNoteUpdatesNotes()
        {
            // arrange
            _user.Notes = new List<Note> { _note1, _note2, _note3, _note4 };

            var users = new List<User> { _user };
            var notes = new List<Note> { _amendNote1, _amendNote2 };

            // act
            var result = _testClass.UpdateUserNotes(users, notes);

            // assert
            Assert.Equal(result[0].Notes[0].Value, _amendNote1.Value);
            Assert.Equal(result[0].Notes[0].Id, _amendNote1.Id);
            Assert.Equal(result[0].Notes[1].Value, _amendNote2.Value);
            Assert.Equal(result[0].Notes[1].Id, _amendNote2.Id);
            Assert.Equal(result[0].Notes[2].Value, _note3.Value);
            Assert.Equal(result[0].Notes[3].Value, _note4.Value);

        }
        [Fact]
        public void GivenMultipleUsertsItAmendsCorrectNotes()
        {
            // arrange
            _user.Notes = new List<Note> { _note1, _note4 };
            _user2.Notes = new List<Note> { _note2, _note3 };

            var users = new List<User> { _user, _user2 };
            var notes = new List<Note> { _amendNote1, _amendNote2 };

            // act
            var result = _testClass.UpdateUserNotes(users, notes);
            var resultingNote1 = users[0].Notes.Find(note => note.Id == _note1.Id);
            var resultingNote2 = users[1].Notes.Find(note => note.Id == _note2.Id);
            var resultingNote3 = users[1].Notes.Find(note => note.Id == _note3.Id);
            var resultingNote4 = users[0].Notes.Find(note => note.Id == _note4.Id);

            // assert
            Assert.Equal(resultingNote1.Value, _amendNote1.Value);
            Assert.Equal(resultingNote2.Value, _amendNote2.Value);
            Assert.Equal(resultingNote3.Value, _note3.Value);
            Assert.Equal(resultingNote4.Value, _note4.Value);

        }
    }
}
