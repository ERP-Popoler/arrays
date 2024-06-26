using System;
using System.Threading;

class JuegoDeMemoria
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Juego de Memoria";
        MostrarBienvenida();

        string nombreUsuario = SolicitarNombreUsuario();

        bool jugarDeNuevo;
        do
        {
            jugarDeNuevo = false;
            JugarJuegoDeMemoria(nombreUsuario);

            Console.WriteLine("¿Quieres jugar de nuevo? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                jugarDeNuevo = true;
            }
        } while (jugarDeNuevo);

        Console.WriteLine("¡Gracias por jugar! Presiona cualquier tecla para salir...");
        Console.ReadKey(true);
    }

    static void MostrarBienvenida()
    {
        Console.WriteLine("                                   ******************************************");
        string teambigote = @"
          _____                                                                                                                                           _____                                                                                                                                           _____ 
         ( ___ )                                                                                                                                         ( ___ )
          |   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|   | 
          |   |                                                                                                                                           |   | 
          |   |                                                                                                                                           |   | 
          |   |    ,--.--------.     ,----.    ,---.             ___                       .=-.-.     _,---.      _,.---._    ,--.--------.     ,----.    |   | 
          |   |   /==/,  -   , -\ ,-.--` , \ .--.'  \     .-._ .'=.'\           _..---.   /==/_ / _.='.'-,  \   ,-.' , -  `. /==/,  -   , -\ ,-.--` , \   |   | 
          |   |   \==\.-.  - ,-./|==|-  _.-` \==\-/\ \   /==/ \|==|  |        .' .'.-. \ |==|, | /==.'-     /  /==/_,  ,  - \\==\.-.  - ,-./|==|-  _.-`   |   | 
          |   |    `--`\==\- \   |==|   `.-. /==/-|_\ |  |==|,|  / - |       /==/- '=' / |==|  |/==/ -   .-'  |==|   .=.     |`--`\==\- \   |==|   `.-.   |   | 
          |   |         \==\_ \ /==/_ ,    / \==\,   - \ |==|  \/  , |       |==|-,   '  |==|- ||==|_   /_,-. |==|_ : ;=:  - |     \==\_ \ /==/_ ,    /   |   | 
          |   |         |==|- | |==|    .-'  /==/ -   ,| |==|- ,   _ |       |==|  .=. \ |==| ,||==|  , \_.' )|==| , '='     |     |==|- | |==|    .-'    |   | 
          |   |         |==|, | |==|_  ,`-._/==/-  /\ - \|==| _ /\   |       /==/- '=' ,||==|- |\==\-  ,    (  \==\ -    ,_ /      |==|, | |==|_  ,`-._   |   | 
          |   |         /==/ -/ /==/ ,     /\==\ _.\=\.-'/==/  / / , /      |==|   -   / /==/. / /==/ _  ,  /   '.='. -   .'       /==/ -/ /==/ ,     /   |   | 
          |   |         `--`--` `--`-----``  `--`        `--`./  `--`       `-._`.___,'  `--`-`  `--`------'      `--`--''         `--`--` `--`-----``    |   | 
          |   |                                                                                                                                           |   | 
          |   |                                                                                                                                           |   | 
          |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___| 
         (_____)                                                                                                                                         (_____)"; 
 
          Console.WriteLine("                                 ******************************************");

        string bienvenida = @"
         /*  _____                                                                                                                                _____  */
         /* ( ___ )                                                                                                                              ( ___ ) */
         /*  |   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|   |  */
         /*  |   |                                                                                                                                |   |  */
         /*  |   |                                                                                                                                |   |  */
         /*  |   |                          ____                                                             __                                   |   |  */
         /*  |   |                         /\  _`\    __                                             __     /\ \                                  |   |  */
         /*  |   |                         \ \ \L\ \ /\_\      __     ___    __  __     __     ___  /\_\    \_\ \     ___                         |   |  */
         /*  |   |                          \ \  _ <'\/\ \   /'__`\ /' _ `\ /\ \/\ \  /'__`\ /' _ `\\/\ \   /'_` \   / __`\                       |   |  */
         /*  |   |                           \ \ \L\ \\ \ \ /\  __/ /\ \/\ \\ \ \_/ |/\  __/ /\ \/\ \\ \ \ /\ \L\ \ /\ \L\ \                      |   |  */
         /*  |   |                            \ \____/ \ \_\\ \____\\ \_\ \_\\ \___/ \ \____\\ \_\ \_\\ \_\\ \___,_\\ \____/                      |   |  */
         /*  |   |                             \/___/   \/_/ \/____/ \/_/\/_/ \/__/   \/____/ \/_/\/_/ \/_/ \/__,_ / \/___/                       |   |  */
         /*  |   |                                                                     /\_ \                                                      |   |  */
         /*  |   |                                                             __      \//\ \       __                                            |   |  */
         /*  |   |                                                           /'__`\      \ \ \    /'__`\                                          |   |  */
         /*  |   |                                                          /\ \L\.\_     \_\ \_ /\ \L\.\_                                        |   |  */
         /*  |   |                                                          \ \__/.\_\    /\____\\ \__/.\_\                                       |   |  */
         /*  |   |    ____                           __                     __/__/\/_/   _______/ \/____/_/            __                         |   |  */
         /*  |   |   /\  _`\                        /\ \                   /\ \         /\_ \      /\  _`\            /\ \                        |   |  */
         /*  |   |   \ \ \L\ \ _ __   __  __     __ \ \ \____     __       \_\ \      __\//\ \     \ \,\L\_\      __  \ \ \____     __   _ __     |   |  */
         /*  |   |    \ \ ,__//\`'__\/\ \/\ \  /'__`\\ \ '__`\  /'__`\     /'_` \   /'__`\\ \ \     \/_\__ \    /'__`\ \ \ '__`\  /'__`\/\`'__\   |   |  */
         /*  |   |     \ \ \/ \ \ \/ \ \ \_\ \/\  __/ \ \ \L\ \/\ \L\.\_  /\ \L\ \ /\  __/ \_\ \_     /\ \L\ \ /\ \L\.\_\ \ \L\ \/\  __/\ \ \/    |   |  */
         /*  |   |      \ \_\  \ \_\  \ \____/\ \____\ \ \_,__/\ \__/.\_\ \ \___,_\\ \____\/\____\    \ `\____\\ \__/.\_\\ \_,__/\ \____\\ \_\    |   |  */
         /*  |   |       \/_/   \/_/   \/___/  \/____/  \/___/  \/__/\/_/  \/__,_ / \/____/\/____/     \/_____/ \/__/\/_/ \/___/  \/____/ \/_/    |   |  */
         /*  |   |                                                                                                                                |   |  */
         /*  |   |                                                                                                                                |   |  */
         /*  |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___|  */
         /* (_____)                                                                                                                              (_____) */";
        
        // Animación para mostrar el arte ASCII letra por letra
        foreach (char c in asciiArt)
        {
            Console.Write(c);
           // Thread.Sleep(1000); // Pausa para efecto visual
        }

        Console.WriteLine("\nEl objetivo del juego es encontrar todas las parejas de cartas.");
        Console.WriteLine("Tienes un número limitado de intentos para descubrir las cartas.");
        Console.WriteLine("Presiona la tecla ESPACIO para empezar...");
        while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        Console.WriteLine("\n¡Buena suerte!\n");
    }

    static string SolicitarNombreUsuario()
    {
        Console.Write("Por favor, introduce tu nombre: ");
        return Console.ReadLine();
    }

    static void AplicarDegradado()
    {
        Console.Clear();
        int altura = Console.WindowHeight;

        for (int i = 0; i < altura; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
    }

    static void JugarJuegoDeMemoria(string nombreUsuario)
    {
        int filas = 4, columnas = 4, intentos = 12; // Cambiado el número de intentos a 12
        char[,] tablero = InicializarTablero(filas, columnas);
        int cartasRestantes = filas * columnas, movimientos = 0;

        while (cartasRestantes > 0 && intentos > 0)
        {
            MostrarTablero(tablero, filas, columnas);
            if (intentos == 1)
            {
                Console.WriteLine("¡Atención! Te queda solo un intento.");
            }

            int[] pos1 = SeleccionarCarta(filas, columnas, tablero);
            MostrarCarta(tablero, pos1[0], pos1[1]);

            int[] pos2 = SeleccionarCarta(filas, columnas, tablero);
            MostrarCarta(tablero, pos2[0], pos2[1]);

            if (tablero[pos1[0], pos1[1]] == tablero[pos2[0], pos2[1]])
            {
                Console.WriteLine("¡Encontraste una pareja!");
                tablero[pos1[0], pos1[1]] = tablero[pos2[0], pos2[1]] = ' ';
                cartasRestantes -= 2;
            }
            else
            {
                Console.WriteLine("Las cartas no coinciden. Inténtalo de nuevo.");
                Thread.Sleep(2000);
            }

            movimientos++;
            intentos--;

            if (intentos == 0 && cartasRestantes > 0)
            {
                Console.WriteLine("¡Oh no! Te has quedado sin intentos.");
            }
        }

        MostrarTablero(tablero, filas, columnas);
        if (cartasRestantes == 0)
        {
            Console.WriteLine($"¡Felicidades {nombreUsuario}! Has encontrado todas las parejas en {movimientos} movimientos.");
        }
        else
        {
            Console.WriteLine($"¡Mejor suerte la próxima vez, {nombreUsuario}!");
        }
    }

    static char[,] InicializarTablero(int filas, int columnas)
    {
        char[,] tablero = new char[filas, columnas];
        char letra = 'A';
        Random random = new Random();

        for (int i = 0; i < filas * columnas / 2; i++)
        {
            int x1, y1, x2, y2;
            do { x1 = random.Next(filas); y1 = random.Next(columnas); } while (tablero[x1, y1] != '\0');
            do { x2 = random.Next(filas); y2 = random.Next(columnas); } while (tablero[x2, y2] != '\0' || (x1 == x2 && y1 == y2));

            tablero[x1, y1] = tablero[x2, y2] = letra++;
        }

        for (int i = 0; i < filas; i++)
            for (int j = 0; j < columnas; j++)
                if (tablero[i, j] == '\0')
                    tablero[i, j] = 'X';

        return tablero;
    }

    static void MostrarTablero(char[,] tablero, int filas, int columnas)
    {
        Console.Clear();
        AplicarDegradado();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Tablero:");
        Console.Write("  ");
        for (int j = 0; j < columnas; j++) Console.Write($"{j + 1} ");
        Console.WriteLine();
        for (int i = 0; i < filas; i++)
        {
            Console.Write($"{i + 1} ");
            for (int j = 0; j < columnas; j++)
            {
                if (tablero[i, j] == ' ') Console.Write("  ");
                else Console.Write("X ");
            }
            Console.WriteLine();
        }
    }

    static int[] SeleccionarCarta(int filas, int columnas, char[,] tablero)
    {
        int[] posicion = new int[2];
        while (true)
        {
            Console.Write("Selecciona una carta (fila columna): ");
            string[] coordenadas = Console.ReadLine().Split();
            if (coordenadas.Length == 2 && int.TryParse(coordenadas[0], out int fila) && int.TryParse(coordenadas[1], out int columna))
            {
                if (fila >= 1 && fila <= filas && columna >= 1 && columna <= columnas && tablero[fila - 1, columna - 1] != ' ' && tablero[fila - 1, columna - 1] != 'X')
                {
                    posicion[0] = fila - 1;
                    posicion[1] = columna - 1;
                    Console.WriteLine("¡Buena elección!");
                    break;
                }
                else
                {
                    Console.WriteLine("Error: La carta ya ha sido encontrada o está oculta. Inténtalo de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Error: Entrada inválida. Por favor, ingresa el número de fila y columna separados por un espacio.");
            }
        }
        return posicion;
    }

    static void MostrarCarta(char[,] tablero, int x, int y)
    {
        Console.WriteLine($"Carta seleccionada: {x + 1}, {y + 1} - Contenido: {tablero[x, y]}");
    }
}