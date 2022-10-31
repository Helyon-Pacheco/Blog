using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar categoria");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id da categoria que deseja alterar: ");
            var id = Console.ReadLine()!;
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Update(new Category
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
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