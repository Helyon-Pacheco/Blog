using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar novo post");
            Console.WriteLine("--------------");
            Console.WriteLine("Título: ");
            var title = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;
            Create(new Post
            {
                Title = title,
                Slug = slug
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}