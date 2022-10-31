using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar nova categoria");
            Console.WriteLine("--------------");
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Create(new Category
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a categoria!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}