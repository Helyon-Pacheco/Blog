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
            Console.WriteLine("Título: ");
            var title = Console.ReadLine()!;
            Console.WriteLine("Sumario: ");
            var summary = Console.ReadLine()!;
            Console.WriteLine("Corpo: ");
            var body = Console.ReadLine()!;
            Console.WriteLine("Id Autor: ");
            var authorId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Id Categoria: ");
            var categoryId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Update(new Post
            {
                Id = int.Parse(id),
                Title = title,
                Summary = summary,
                Body = body,
                AuthorId = authorId,
                CategoryId = categoryId,
                Slug = slug
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