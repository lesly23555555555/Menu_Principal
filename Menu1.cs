using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Menu_Principal
{
    internal class Menu1
    { 
        public void Menu_1() {
            MenuPrincipal mp = new MenuPrincipal();
            Console.Clear();
            bool w = true;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("            --> Menú 1: Programas de Introducción <--");
                Console.WriteLine("Selecciona la opción que deseas realizar: \n " +
                    "1) Generar rectángulos con asteriscos \n " +
                    "2) Generar barras con asteriscos \n " +
                    "3) Generar espiral con asteriscos \n " +
                    "4) Menú anterior \n " +
                    "5) Continuar \n "+
                    "6) Salir");
                char opcion = Convert.ToChar(Console.ReadLine());
                switch (opcion)
                {
                    case '1':
                        DibujarEspiral();
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        esp();
                        Console.Clear();
                        break;
                    case '3':
                        Console.Clear();
                        DibujoEspiralCircular();
                        break;
                    case '4':
                        Console.Clear();
                        mp.Menu_Principal();
                        w = false;
                        break;
                    case '5':
                        Console.Write("Adelante, elige otra opción!");
                        break;
                    case '6':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción invalida");
                        break;
                }
            } while (w);
        }

        public static void DibujarEspiral()
        {
            // Esto es para definir la posición donde comienza a dibujar los asteriscos
            int startX = 30;
            int startY = 10;

            // Aquí se definen los anchos y altos de los rectángulos
            int[] widths = { 55, 35, 25, 15, 3 };
            int[] heights = { 17, 13, 9, 5, 1 };

            ConsoleColor[] colores = {
                ConsoleColor.Green,   // Color central
                ConsoleColor.Yellow,  // Segundo color
                ConsoleColor.Red,     // Tercer color
                ConsoleColor.Blue,    // Cuarto color
                ConsoleColor.Cyan     // Quinto color
            };

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;

            // Dibuja desde el centro hacia afuera
            for (int i = 4; i >= 0; i--)
            {
                int currentWidth = widths[i];
                int currentHeight = heights[i];
                // Calcula la posición para centrar cada rectángulo
                int currentX = startX + (widths[0] - currentWidth) / 2;
                int currentY = startY + (heights[0] - currentHeight) / 2;

                DibujarRectanguloAnimado(
                    currentX,
                    currentY,
                    currentWidth,
                    currentHeight,
                    colores[4 - i],
                    i == 4  // Si es el último rectángulo (centro)
                );
                Thread.Sleep(500); // Pausa entre dibujos
            }
        }

        static void DibujarRectanguloAnimado(int x, int y, int width, int height, ConsoleColor color, bool esCentro)
        {
            Console.ForegroundColor = color;

            if (esCentro)
            {
                // Dibuja solo los tres asteriscos de en medio
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(x + i, y);
                    Console.Write("*");
                    Thread.Sleep(100);
                }
                return;
            }

            // Dibuja el rectángulo de derecha a izquierda

            // Lado derecho (de arriba a abajo)
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x + width - 1, y + i);
                Console.Write("*");
                Thread.Sleep(50);
            }

            // Lado inferior (de derecha a izquierda)
            for (int i = width - 2; i >= 0; i--)
            {
                Console.SetCursorPosition(x + i, y + height - 1);
                Console.Write("*");
                Thread.Sleep(50);
            }

            // Lado izquierdo (de abajo a arriba)
            for (int i = height - 2; i >= 0; i--)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("*");
                Thread.Sleep(50);
            }

            // Lado superior (de izquierda a derecha)
            for (int i = 1; i < width - 1; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("*");
                Thread.Sleep(50);
            }
        }

        public void esp()
        {
            //Variables
            int rep = 12;
            Boolean est = false;
            int cont = 0;

            //For que indica cuantas repeticiones se haran del patron
            for (int i = 0; i <= rep; i++)
            {

                //Si est es falso, significa que toca dibujar la linea inferior y la linea vertical que va de abajo a arriba
                if (est == false)
                {
                    //Linea inferior
                    for (int j = 0; j < 6; j++)
                    {
                        Console.SetCursorPosition(cont, 20);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        cont += 1;
                    }
                    est = true;

                    //Linea vertical
                    //El if es la condicion para que la ultima linea vertical no se muestre
                    if (cont < ((rep + 1) * 7) - 1)
                    {
                        for (int j = 20; j > 6; j--)
                        {
                            Console.SetCursorPosition(cont, j);
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            System.Threading.Thread.Sleep(100);
                            Console.WriteLine("*");

                        }
                        cont += 1;
                    }


                    //En caso de ser falso, significa que corresponde hacer la linea superior y la vertical de arriba a abajo
                }
                else
                {
                    //linea superior
                    for (int j = 0; j < 6; j++)
                    {
                        Console.SetCursorPosition(cont, 7);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        cont += 1;
                        est = false;
                    }
                    //Linea vertical
                    for (int j = 7; j < 21; j++)
                    {
                        Console.SetCursorPosition(cont, j);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");

                    }
                    cont += 1;

                }
            }
            Console.ReadKey();

        }


        public void DibujoEspiralCircular()
        {
            int inicioX = 50;
            int desplazamientoX = 50;
            int valorX = 0;
            int inicioY = 13;
            int desplazamientoY = 13;
            int valorY = 0;
            bool alternarDireccion = false;
            ConsoleColor[] paletaColores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.Cyan };
            int indiceColor = 0;
            int repeticiones = 10;

            for (int i = repeticiones; i >= 0; i--)
            {
                if (!alternarDireccion)
                {
                    valorX += 5;
                    desplazamientoX -= valorX;
                    valorY += 2;
                    desplazamientoY -= valorY;

                    while (inicioX > desplazamientoX + 1)
                    {
                        Console.SetCursorPosition(inicioX, inicioY);
                        Console.ForegroundColor = paletaColores[indiceColor];
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        inicioX -= 1;
                        if (indiceColor == 4)
                        {
                            indiceColor = 0;
                        }
                        else
                        {
                            indiceColor++;
                        }
                    }

                    while (inicioY > desplazamientoY)
                    {
                        Console.SetCursorPosition(inicioX, inicioY);
                        Console.ForegroundColor = paletaColores[indiceColor];
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        inicioY -= 1;
                        if (indiceColor == 4)
                        {
                            indiceColor = 0;
                        }
                        else
                        {
                            indiceColor++;
                        }
                    }

                    alternarDireccion = true;
                }
                else
                {
                    valorX += 5;
                    desplazamientoX += valorX;
                    valorY += 2;
                    desplazamientoY += valorY;

                    while (inicioX < desplazamientoX)
                    {
                        Console.SetCursorPosition(inicioX, inicioY);
                        Console.ForegroundColor = paletaColores[indiceColor];
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        inicioX += 1;
                        if (indiceColor == 4)
                        {
                            indiceColor = 0;
                        }
                        else
                        {
                            indiceColor++;
                        }
                    }

                    while (inicioY < desplazamientoY)
                    {
                        Console.SetCursorPosition(inicioX, inicioY);
                        Console.ForegroundColor = paletaColores[indiceColor];
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("*");
                        inicioY += 1;
                        if (indiceColor == 4)
                        {
                            indiceColor = 0;
                        }
                        else
                        {
                            indiceColor++;
                        }
                    }

                    alternarDireccion = false;
                }
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}