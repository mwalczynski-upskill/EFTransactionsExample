using System;
using System.CodeDom;
using System.Collections.Generic;
using EFTransactionsExample.Models.EFPaginationExample.Models;
using EFTransactionsExample.Repositories;

namespace EFTransactionsExample
{
    class Program
    {
        public static Repository Repository = new Repository();

        static void Main(string[] args)
        {
            Add();
            Delete();
            Console.ReadKey();
        }

        public static void Add()
        {
            var personsThatWillAdd = new List<Person>()
            {
                new Person("Z", "Z", 26)
            };
            Repository.AddInTransaction(personsThatWillAdd);

            var personsBeforeTransaction = Repository.SelectAll();
            foreach (var person in personsBeforeTransaction)
            {
                Console.WriteLine($@"{person.FirstName}, {person.SecondName}, {person.Age}");
            }

            var personsThatWontAdd = new List<Person>()
            {
                new Person("A", "A", 1),
                new Person("B", "B", 2),
                new Person("C", "C", 3),
                new Person("D", "D")
            };
            Repository.AddInTransaction(personsThatWontAdd);

            var personsAfterTransactions = Repository.SelectAll();
            foreach (var person in personsAfterTransactions)
            {
                Console.WriteLine($@"{person.FirstName}, {person.SecondName}, {person.Age}");
            }
        }

        public static void Delete()
        {
            Repository.DeleteInTransaction(new Person("Z", "Z", 25));    
        }
    }

}
