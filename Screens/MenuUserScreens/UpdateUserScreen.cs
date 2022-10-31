using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do usuário que deseja alterar: ");
            var id = Console.ReadLine()!;
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
            Update(new User
            {
                Id = int.Parse(id),
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

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Atualização realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}