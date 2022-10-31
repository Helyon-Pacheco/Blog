using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MenuCategoryScreens;
using Blog.Screens.MenuPostScreens;
using Blog.Screens.MenuRoleScreens;
using Blog.Screens.MenuTagScreens;
using Blog.Screens.MenuUserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=123456Sa;Trusted_Connection=False;TrustServerCertificate=True;";
        public static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();
            
            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Gestão de post");
            //Console.WriteLine("6 - Vincular perfil/usuário");
            //Console.WriteLine("7 - Vincular post/tag");
            //Console.WriteLine("8 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
