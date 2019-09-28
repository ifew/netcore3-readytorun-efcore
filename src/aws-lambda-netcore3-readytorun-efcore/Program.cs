using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Member
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Log: Start Connection");
            
            using (var context = new EFContext())
            {
                Console.WriteLine("Log: Before: context.Members.ToList()");

                var result = context.Members.ToList();

                Console.WriteLine("Log: Result Count: " + result.Count() + "\n");
                Console.WriteLine("Log: Result: " + JsonConvert.SerializeObject(result.ToList()));
            }

        }
    }

    class EFContext : DbContext
    {
        
        public DbSet<Member> Members { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"));
        }
    }

    [Table("member")]
    public class Member
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

    }
}
