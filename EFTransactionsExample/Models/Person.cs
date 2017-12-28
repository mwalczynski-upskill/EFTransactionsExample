using System.ComponentModel.DataAnnotations;

namespace EFTransactionsExample.Models
{
    namespace EFPaginationExample.Models
    {
        public class Person
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            [Required]
            public int? Age { get; set; }

            public Person() { }

            public Person(string firstName, string secondName)
            {
                FirstName = firstName;
                SecondName = secondName;
            }

            public Person(string firstName, string secondName, int age)
            {
                FirstName = firstName;
                SecondName = secondName;
                Age = age;
            }
        }
    }
}
