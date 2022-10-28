using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuRoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar perfil");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do perfil que deseja alterar: ");
            var id = Console.ReadLine()!;
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Update(new Role
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine("Atualização realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}