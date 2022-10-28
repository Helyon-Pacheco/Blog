﻿using System;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=123456Sa;Trusted_Connection=False;TrustServerCertificate=True;";
        public static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsers(connection);
            ReadRoles(connection);
            ReadTags(connection);
            ReadUsersWithRoles(connection);
            
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
            
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "Name",
                Email = "email@balta.io",
                Bio = "bio",
                Image = "imagem",
                PasswordHash = "hash",
                Slug = "slug"
            };
            var repository = new Repository<User>(connection);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }
}
