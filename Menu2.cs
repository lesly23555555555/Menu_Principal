using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

public class Menu2
{
    public void Menu_2()
    {
        Console.Clear();
        bool w = true;

        do
        {
            Console.WriteLine("            --> Menú 2 <--");
            Console.WriteLine("Selecciona la opción que deseas realizar: \n " +
                "a) Tabla de Senos (0° - 90°) \n " +
                "b) Tabla de Cosenos (0° - 90°) \n " +
                "c) Regresar al Menú Principal \n " +
                "d) Calcular parámetros de una recta dados dos puntos \n " +
                "e) Trayectoria de un proyectil \n " +
                "f) Salir");

            char opcion = Convert.ToChar(Console.ReadLine());

            Console.Clear();

            switch (opcion)
            {
                case 'a':
                    MostrarTablaSeno();
                    break;
                case 'b':
                    MostrarTablaCoseno();
                    break;
                case 'd':
                    CalcularParametrosRecta();
                    break;
                case 'e':
                    CalcularTrayectoriaProyectil();
                    break;
                case 'f':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine("\nPresiona (m) para volver al menú o cualquier otra tecla para salir.");
            string opc = Console.ReadLine();
            if (opc != "m")
            {
                Environment.Exit(0);
            }

        } while (w);
    }

    static void MostrarTablaSeno()
    {
        Console.Clear();
        Console.WriteLine("Tabla de Senos (0° - 90°):\n");

        for (int i = 0; i <= 90; i++)
        {
            double radianes = (i * Math.PI) / 180;
            double seno = Math.Sin(radianes);

            Console.WriteLine($"{i,3}°: {seno:F4}");
        }
    }

    static void MostrarTablaCoseno()
    {
        Console.Clear();
        Console.WriteLine("Tabla de Cosenos (0° - 90°):\n");

        for (int i = 0; i <= 90; i++)
        {
            double radianes = (i * Math.PI) / 180;
            double coseno = Math.Cos(radianes);

            Console.WriteLine($"{i,3}°: {coseno:F4}");
        }
    }

    static void CalcularParametrosRecta()
    {
        Console.WriteLine("Ingresa las coordenadas del primer punto (x1, y1):");
        Console.Write("x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingresa las coordenadas del segundo punto (x2, y2):");
        Console.Write("x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        // a) Esto es para calcular la pendiente (m)
        double pendiente = (y2 - y1) / (x2 - x1);
        Console.WriteLine($"a) La pendiente de la recta es: {pendiente:F4}");

        // b) Esto para calcular el ángulo de inclinación (en grados)
        double anguloRad = Math.Atan(pendiente); // en radianes
        double anguloGrados = anguloRad * 180 / Math.PI; // convertir a grados
        Console.WriteLine($"b) El ángulo de inclinación de la recta es: {anguloGrados:F2}°");

        // c) Esto calcula el punto medio
        double puntoMedioX = (x1 + x2) / 2;
        double puntoMedioY = (y1 + y2) / 2;
        Console.WriteLine($"c) Las coordenadas del punto medio son: ({puntoMedioX:F2}, {puntoMedioY:F2})");

        // Con esto se crea la gráfica de la recta
        Console.WriteLine("\nGráfico de la recta:");
        GraficarRecta(x1, y1, x2, y2);

        Console.WriteLine("\nPresiona (m) para volver al menú o cualquier otra tecla para salir.");
        string opc = Console.ReadLine();
        if (opc != "m")
        {
            Environment.Exit(0);
        }
    }

    static void GraficarRecta(double x1, double y1, double x2, double y2)
    {
        double escala = 2.0; // Es para el factor de escala para la consola
        int maxX = 30; // Ancho de la gráfica
        int maxY = 20; // Alto de la gráfica

        //Aqui se ajustan las coordenadas para la gráfica
        int x1G = (int)(x1 * escala);
        int y1G = maxY - (int)(y1 * escala);
        int x2G = (int)(x2 * escala);
        int y2G = maxY - (int)(y2 * escala);

        char[,] grid = new char[maxY + 1, maxX + 1];

        // Inicializar la cuadrícula con espacios vacíos
        for (int i = 0; i <= maxY; i++)
        {
            for (int j = 0; j <= maxX; j++)
            {
                grid[i, j] = ' ';
            }
        }

        // Dibuja los puntos en la cuadrícula
        grid[y1G, x1G] = '*';
        grid[y2G, x2G] = '*';

        // Mostrar la cuadrícula
        for (int i = maxY; i >= 0; i--)
        {
            for (int j = 0; j <= maxX; j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void CalcularTrayectoriaProyectil()
    {
        Console.Write("Introduce la velocidad inicial del proyectil (m/s): ");
        double velocidadInicial = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el ángulo de lanzamiento del proyectil (grados): ");
        double angulo = Convert.ToDouble(Console.ReadLine());

        Console.Clear();

        double gravedad = 9.81;

        //Se convierte el angulo en radianes
        double anguloRadianes = angulo * Math.PI / 180;

        // Calcular componentes de la velocidad inicial
        double velocidadInicialX = velocidadInicial * Math.Cos(anguloRadianes);
        double velocidadInicialY = velocidadInicial * Math.Sin(anguloRadianes);

        double tiempoVuelo = (2 * velocidadInicialY) / gravedad;
        double intervaloTiempo = tiempoVuelo / 10;

        double x, y;

        double alturaMaxima = Math.Pow(velocidadInicialY, 2) / (2 * gravedad);
        double distanciaMaxima = Math.Pow(velocidadInicial, 2) * Math.Sin(2 * anguloRadianes) / gravedad;
        double velocidadMaxima = Math.Sqrt(Math.Pow(velocidadInicialX, 2) + Math.Pow(velocidadInicialY - gravedad * tiempoVuelo, 2));
        double velocidadFinalY = 0;

        Console.WriteLine("\nGráfico de la trayectoria del proyectil:\n");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (double i = 0; i <= tiempoVuelo; i += intervaloTiempo)
        {
            // Calcular las coordenadas X, Y para el tiempo actual
            x = velocidadInicialX * i;
            y = velocidadInicialY * i - 0.5 * gravedad * Math.Pow(i, 2);

            int xConsola = (int)Math.Round(x);
            int yConsola = (int)Math.Round(y);

            // Dibuja el proyectil en la consola

            Console.SetCursorPosition(xConsola + 10, Console.WindowHeight - yConsola - 2);
            Console.Write("*");

            velocidadFinalY = velocidadInicialY - gravedad * i;
        }

        Console.ResetColor();
        // Muestra las coordenadas (x, y) debajo del gráfico
        Console.WriteLine("\n\nCoordenadas (x, y):\n");
        for (double i = 0; i <= tiempoVuelo; i += intervaloTiempo)
        {
            x = velocidadInicialX * i;
            y = velocidadInicialY * i - 0.5 * gravedad * Math.Pow(i, 2);
            Console.WriteLine($"({x:F2}, {y:F2})");
        }

        Console.WriteLine($"\nDatos del proyectil:");
        Console.WriteLine($"Velocidad inicial: {velocidadInicial} m/s");
        Console.WriteLine($"Ángulo de lanzamiento: {angulo} grados");
        Console.Write("-----------------------------------------------");
        Console.WriteLine($"\nAltura máxima: {alturaMaxima:F2} m");
        Console.WriteLine($"Distancia máxima: {distanciaMaxima:F2} m");
        Console.WriteLine($"Velocidad máxima: {velocidadMaxima:F2} m/s");
        Console.WriteLine($"Velocidad inicial en Y: {velocidadInicialY:F2} m/s");
        Console.WriteLine($"Velocidad final en Y: {velocidadFinalY:F2} m/s \n");
    }
}