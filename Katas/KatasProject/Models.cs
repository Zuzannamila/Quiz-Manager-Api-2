using System;
using System.Collections.Generic;

namespace Katas.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
    }

    public class Note
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }

    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int HeightCM { get; set; }
    }

    public class Artwork
    {
        public string Desctiption { get; set; }
        public string Artist { get; set; }
        public DateTime submissionTimestamp { get; set; }
    }

    public class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public int Tricks { get; set; }
    }

    public class Cat : Animal
    {
        public int PurrLoudness { get; set; }
    }
}
