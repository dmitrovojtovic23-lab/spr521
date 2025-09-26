using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace FinalEntityFramework
{
    internal class Program
    {
        class Bookstore
        {
            public int Id { get; set; }
            public string NameBook { get; set; }
            public string number_of_pages { get; set; }
            public override string ToString()
            {
                return $"Id = {Id} , NameBook = {NameBook} , Number_of_pages = {number_of_pages}";
            }
            Author Author { get; set; }
        }
        class Author
        {
            public int Id { get; set; }
            public string NameAuthor { get; set; }
            public string SurnameAuthor { get; set; }
            public string LastNameAuthor { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return $"Id = {Id} , NameAuthor = {NameAuthor} , SurnameAuthor = {SurnameAuthor} , LastNameAuthor = {LastNameAuthor} , Age = {Age}";
            }
            Country Country { get; set; }
            public ICollection<Bookstore> Book { get; set; }

        }
        class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return $"Id = {Id} , Name = {Name}";
            }
            public ICollection<City> Cities { get; set; }
        }
        class Publisher
        {
            public int Id { get; set; }
            public string name_of_the_publisher { get; set; }
            public override string ToString()
            {
                return $"Id = {Id} , Name of the publisher = {name_of_the_publisher}";
            }
            City City { get; set; }
            int CityId { get; set; }
            public ICollection<Bookstore> Book { get; set; }
        }
        class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return $"Id = {Id} , Name = {Name}";
            }
            Country Country { get; set; }
            public ICollection<Publisher> Publishers { get; set; }
        }
        class Genre
        {
            public int Id { get; set; }
            public string name;
            public override string ToString()
            {
                return $"Id = {Id} , Name = {name}";
            }
            public ICollection<Bookstore> Book { get; set; }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
