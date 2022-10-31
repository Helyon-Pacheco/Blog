using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do usuário que deseja excluir? ");
            var id = Console.ReadLine()!;
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}