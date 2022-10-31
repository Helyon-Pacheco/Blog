using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar novo usuário");
            Console.WriteLine("--------------");
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Email: ");
            var email = Console.ReadLine()!;
            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine()!;
            Console.WriteLine("Url Imagem: ");
            var image = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = "HASH",
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}