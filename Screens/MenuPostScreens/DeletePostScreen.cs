using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir post");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do post que deseja excluir? ");
            var id = Console.ReadLine()!;
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}