using System;
using EFInClass.Models;
using Microsoft.EntityFrameworkCore;

namespace EFInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while(!exit)
            {
                Console.Clear();
                System.Console.WriteLine("1. Display Blogs");
                System.Console.WriteLine("2. Add Blog");
                System.Console.WriteLine("3. Display Posts");
                System.Console.WriteLine("4. Add Post");
                var choice = Console.ReadLine();
                // display blogs
                if(choice == "1")
                {
                    Console.Clear();
                    using (var db = new BlogContext())
                    {
                        var blogs = db.Blogs;
                        foreach(var blog in blogs)
                        {
                            System.Console.WriteLine("{0}. {1}", blog.BlogID, blog.Name);
                        }
                    }
                    Console.ReadKey();
                }
                // add blog
                else if(choice == "2")
                {
                    Console.Clear();
                    System.Console.WriteLine("Name of new Blog: ");
                    var name = Console.ReadLine();
                    using (var db = new BlogContext())
                    {
                        var blog = new Blog()
                        {
                            Name = name
                        };
                        db.Blogs.Add(blog);
                        db.SaveChanges();
                    }
                    System.Console.WriteLine("Blog Added!");
                    Console.ReadKey();
                }
                // display posts
                else if(choice == "3")
                {
                    Console.Clear();
                    using (var db = new BlogContext())
                    {
                        var blogs = db.Blogs
                                        .Include(b => b.Posts);

                        foreach (var blog in blogs)
                        {
                            System.Console.WriteLine("Blog");
                            System.Console.WriteLine("{0, -3} {1}", blog.BlogID, blog.Name);
                            foreach (var post in blog.Posts)
                            {
                                System.Console.WriteLine("\tPosts");
                                System.Console.WriteLine("\t{0, -3} {1}", post.PostID, post.Title);
                                System.Console.WriteLine("\t\t{0}", post.Content);
                            }
                        }
                    }
                    Console.ReadKey();
                }
                // add post
                else if(choice == "4")
                {
                    Console.Clear();
                    using (var db = new BlogContext())
                    {
                        System.Console.WriteLine("Choose blog to add to:");
                        var blogs = db.Blogs;
                        foreach (var blog in blogs)
                        {
                            System.Console.WriteLine("{0}. {1}", blog.BlogID, blog.Name);
                        }
                        var blogChoice = Console.ReadLine();
                        System.Console.WriteLine("New post title:");
                        var newTitle = Console.ReadLine();
                        System.Console.WriteLine("New post content:");
                        var newContent = Console.ReadLine();
                        var newPost = new Post()
                        {
                            Title = newTitle,
                            Content = newContent,
                            BlogID = Convert.ToInt32(blogChoice)
                        };
                        db.Posts.Add(newPost);
                        db.SaveChanges();
                    }
                }
                else
                {
                    exit = true;
                }
            }






        }
    }
}
