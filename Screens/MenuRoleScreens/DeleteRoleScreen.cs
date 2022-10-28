using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuRoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir perfil");
            Console.WriteLine("--------------");
            Console.WriteLine("Digite o Id do perfil que deseja excluir? ");
            var id = Console.ReadLine()!;
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o perfil!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}