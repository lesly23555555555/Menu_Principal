using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Principal
{
    internal class MenuPrincipal
    {
        // x -> De izquierda hacia abajo
        // y -> De arriba hacia abajo
        char opcion;
        static void Main(string[] args)
        {
            MenuPrincipal mp = new MenuPrincipal();
            mp.Menu_Principal();

        }

        public void Menu_Principal()
        {
            int x = 10;
            int y = 1;
            Console.Clear();
            Console.SetCursorPosition(x,y);
            Console.WriteLine("--> Menú Principal <--");
            Console.WriteLine("\tLesly Gomez Hernandez");
            Console.WriteLine("Selecciona una opción que deseas realizar: \n " +
                "a) Abrir el Menú 1 \n " +
                "b) Abrir el Menú 2 \n " +
                "d) Salir");
            try
            {
                opcion = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("Introduce una opción valida"+ "\n Error! "+e);
                Menu_Principal();
            }
            switch (opcion) {
                case 'a':
                    Menu1 m1 = new Menu1();
                    m1.Menu_1();
                    break;
                case 'b':
                    Menu2 m2 = new Menu2();
                    m2.Menu_2();
                    break;
                case 'd':

                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción invalida");
                    Menu_Principal();
                    break;
            }
        }
    }
}

