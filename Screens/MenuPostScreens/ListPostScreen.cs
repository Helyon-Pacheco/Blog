using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts");
            Console.WriteLine("--------------");
            List();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void List()
        {
            var repository = new Repository<Post>(Database.Connection);
            var posts = repository.Get();
            foreach (var item in posts)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.CategoryId})");
        }
    }
}