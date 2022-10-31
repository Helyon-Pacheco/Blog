using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("--------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.Get();
            foreach (var item in users)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug}) - {item.Bio} - {item.Email} {item.Image})");
        }
    }
}