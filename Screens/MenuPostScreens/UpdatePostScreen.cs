using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar post");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do post que deseja alterar: ");
            var id = Console.ReadLine()!;
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Id da Categoria: ");
            var categoryId = int.Parse(Console.ReadLine()!);
            Update(new Post
            {
                Id = int.Parse(id),
                Name = name,
                CategoryId = categoryId
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Atualização realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}