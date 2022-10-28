using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar tags");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id da tag que deseja excluir? ");
            var id = Console.ReadLine()!;
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}