
// See https://aka.ms/new-console-template for more information

using CodeFirstEntity.Entities;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");


using var db = new BloggingContext();

db.Blogs.Add(new Blog()
{
    Name = "test",
    Id = 4,
});


db.SaveChanges();

Console.ReadLine();