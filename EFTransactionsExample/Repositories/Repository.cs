using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFTransactionsExample.EFPaginationExample;
using EFTransactionsExample.Models.EFPaginationExample.Models;

namespace EFTransactionsExample.Repositories
{
    public class Repository
    {
        public int Add(Person entity)
        {
            using (var context = new EfContext())
            {
                context.Persons.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public void AddInTransaction(List<Person> entities)
        {
            using (var context = new EfContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var entity in entities)
                        {
                            context.Persons.Add(entity);
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Adding Commit");
                    }
                    catch
                    {
                        transaction.Rollback();
                        Console.WriteLine("Adding Rollback");
                    }
                }
            }
        }

        public void DeleteInTransaction(Person entity)
        {
            using (var context = new EfContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Persons.Attach(entity);
                        context.Entry(entity).State = EntityState.Deleted;
                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Delete Commit");
                    }
                    catch
                    {
                        transaction.Rollback();
                        Console.WriteLine("Delete Rollback");
                    }
                }
            }
        }

        public Person SelectById(int id)
        {
            using (var context = new EfContext())
            {
                var result = context.Persons;
                return result.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Person> SelectAll()
        {
            using (var context = new EfContext())
            {
                var result = context.Persons;
                return result.ToList();
            }
        }
    }
}