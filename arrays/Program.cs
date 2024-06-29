using System;
using System.Threading;
using System.Diagnostics;

class JuegoDeMemoria
{
    static void Main(string[] args)
    {
        ConfigurarConsola();
        MostrarBienvenida();

        string nombreUsuario = SolicitarNombreUsuario();

        bool jugarDeNuevo;
        do
        {
            jugarDeNuevo = false;
            JugarJuegoDeMemoria(nombreUsuario);

            Console.Write("\n\n¿Quieres jugar de nuevo? (SI/NO): ");
            string respuesta = Console.ReadLine()?.ToUpper()!;
            if (respuesta == "SI")
            {
                jugarDeNuevo = true;
            }
        } while (jugarDeNuevo);

        MostrarDespedida();
    }

    // Configuración de la consola para soportar UTF-8 y establecer el título del juego.
    static void ConfigurarConsola()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Juego de Memoria";
    }

    // Mostrar pantalla de bienvenida con arte ASCII y mensaje.
    static void MostrarBienvenida()
    {
        Console.Clear();
        ReproducirArchivoAudio("/Users/e.r/Desktop/bienvenida.wav");
        string teamBigote = @"
        __| |_________________________________________________________________________________________________________________________________________| |__
        __   _________________________________________________________________________________________________________________________________________   __
          | |                                                                                                                                         | |
          | |                                                                                                                                         | |
          | |                                                                                                                                         | |
          | |   ,--.--------.     ,----.    ,---.             ___                       .=-.-.     _,---.      _,.---._    ,--.--------.     ,----.   | |
          | |  /==/,  -   , -\ ,-.--` , \ .--.'  \     .-._ .'=.'\           _..---.   /==/_ / _.='.'-,  \   ,-.' , -  `. /==/,  -   , -\ ,-.--` , \  | |
          | |  \==\.-.  - ,-./|==|-  _.-` \==\-/\ \   /==/ \|==|  |        .' .'.-. \ |==|, | /==.'-     /  /==/_,  ,  - \\==\.-.  - ,-./|==|-  _.-`  | |
          | |   `--`\==\- \   |==|   `.-. /==/-|_\ |  |==|,|  / - |       /==/- '=' / |==|  |/==/ -   .-'  |==|   .=.     |`--`\==\- \   |==|   `.-.  | |
          | |        \==\_ \ /==/_ ,    / \==\,   - \ |==|  \/  , |       |==|-,   '  |==|- ||==|_   /_,-. |==|_ : ;=:  - |     \==\_ \ /==/_ ,    /  | |
          | |        |==|- | |==|    .-'  /==/ -   ,| |==|- ,   _ |       |==|  .=. \ |==| ,||==|  , \_.' )|==| , '='     |     |==|- | |==|    .-'   | |
          | |        |==|, | |==|_  ,`-._/==/-  /\ - \|==| _ /\   |       /==/- '=' ,||==|- |\==\-  ,    (  \==\ -    ,_ /      |==|, | |==|_  ,`-._  | |
          | |        /==/ -/ /==/ ,     /\==\ _.\=\.-'/==/  / / , /      |==|   -   / /==/. / /==/ _  ,  /   '.='. -   .'       /==/ -/ /==/ ,     /  | |
          | |        `--`--` `--`-----``  `--`        `--`./  `--`       `-._`.___,'  `--`-`  `--`------'      `--`--''         `--`--` `--`-----``   | |
          | |                                                                                                                                         | |
          | |                                                                                                                                         | |
        __| |_________________________________________________________________________________________________________________________________________| |_
        __   _________________________________________________________________________________________________________________________________________   __
          | |                                                                                                                                         | |  ";
          
        // Mostrar arte ASCII letra por letra
        foreach (char c in teamBigote)
        {
            Console.Write(c);
            Thread.Sleep(0); // Pausa para efecto visual
        }
          
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
            /*  |   |                                                                                                                                |   |  */
            /*  |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___|  */                                                                                                                           
            /*  |   |                                                                                                                                |   |  */ 
            /*  |   |                                                                                                                                |   |  */ 
            /*  |   |                                                                                                                                |   |  */ 
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */ 
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /*  |   |                                                                                                                                |   |  */
            /* (_____)                                                                                                                              (_____) */";

            // Animación para mostrar el arte ASCII letra por letra
            foreach (char c in bienvenida )
            {
                Console.Write(c);
                Thread.Sleep(1); // Pausa para efecto visual
            }
        Console.ReadKey(true);

        // Mensaje de bienvenida
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n                                                   ***¡Bienvenido al la prueba del saber, porque te lo tienes que saber***");
        Console.WriteLine("\n\n                                    Porfi Orison, no rompa el programa poniendo decimales :( nos esforzamos mucho, porfa, no lo dañe \n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n\n                                                                  ^^^Presiona Enter para comenzar^^^\n\n");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {

        }

        Console.Clear();
        Console.WriteLine("                                                        ¡Bienvenido al desafiante y entretenido Juego de Memoria de Cartas! \n                             Prepárate para poner a prueba tus habilidades de memoria en una emocionante aventura llena de diversión y sorpresas.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\n                     Encuentra los pares de cartas ocultas en el tablero antes de que se te acaben los intentos. ¡Tendrás 15 oportunidades para descubrir todos los pares y ganar el juego!");
        Console.ReadKey();
        Console.Clear();
        Console.ResetColor();
    }

    // Función para solicitar y devolver el nombre del usuario.
    static string SolicitarNombreUsuario()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\nKiuvo panita, porfa, ingrese su nombre *guiño, guiño, codo, codo*: ");
        string nombre = Console.ReadLine()!;

        if (!string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine($"\n\n           Hola {nombre}! Bienvenido al la Prueba del Saber");
            Thread.Sleep(3000);
            return nombre!;
        }
        else
        {
            Console.WriteLine("\n                Ingrese un Nombre. ***VAGO***");
            return SolicitarNombreUsuario();
        }
    }

    // Función principal para ejecutar el juego de memoria.
    static void JugarJuegoDeMemoria(string nombreUsuario)
    {
        Console.Clear();
        Console.WriteLine($"Empecemos, {nombreUsuario}!");
        string dedo = @"       
                                    ★░░░░░░░░░░░████░░░░░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░███░██░░░░░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░██░░░█░░░░░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░██░░░██░░░░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░░██░░░███░░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░░░██░░░░██░░░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░░░██░░░░░███░░░░░░░░░░░░░░★
                                    ★░░░░░░░░░░░░██░░░░░░██░░░░░░░░░░░░░★
                                    ★░░░░░░░███████░░░░░░░██░░░░░░░░░░░░★
                                    ★░░░░█████░░░░░░░░░░░░░░███░██░░░░░░★
                                    ★░░░██░░░░░████░░░░░░░░░░██████░░░░░★
                                    ★░░░██░░████░░███░░░░░░░░░░░░░██░░░░★
                                    ★░░░██░░░░░░░░███░░░░░░░░░░░░░██░░░░★
                                    ★░░░░██████████░███░░░░░░░░░░░██░░░░★
                                    ★░░░░██░░░░░░░░████░░░░░░░░░░░██░░░░★
                                    ★░░░░███████████░░██░░░░░░░░░░██░░░░★
                                    ★░░░░░░██░░░░░░░████░░░░░██████░░░░░★
                                    ★░░░░░░██████████░██░░░░███░██░░░░░░★
                                    ★░░░░░░░░░██░░░░░████░███░░░░░░░░░░░★
                                    ★░░░░░░░░░█████████████░░░░░░░░░░░░░★
                                    ★░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░★";

        // Animación para mostrar el arte ASCII letra por letra
        foreach (char c in dedo )
        {
            Console.Write(c);
            Thread.Sleep(1); // Pausa para efecto visual
        }
        Thread.Sleep(2000);

        // Cartas disponibles
        string[] cartas = { "🂡", "🂡", "🂪", "🂤", "🂥", "🂤", "🂥", "🂨", "🂨", "🂪" };

        // Barajar las cartas
        Random rnd = new Random();
        int[] posiciones = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = 0; i < posiciones.Length; i++)
        {
            int rndIndex = rnd.Next(i, posiciones.Length);
            int temp = posiciones[i];
            posiciones[i] = posiciones[rndIndex];
            posiciones[rndIndex] = temp;
        }

        // Tablero de juego
        string[] tablero = new string[10];
        for (int i = 0; i < 10; i++)
        {
            tablero[i] = "🂫"; // Carta de reverso
        }

        // Intentos y pares encontrados
        int intentos = 0;
        int paresEncontrados = 0;

        const int maxIntentos = 10;

        while (paresEncontrados < 5 && intentos < maxIntentos)
        {
            // Mostrar tablero actual
            MostrarTablero(tablero);

            // Solicitar posición de la primera carta
            int posicion1 = SolicitarPosicionCarta("primera");
            while (tablero[posicion1 - 1] != "🂫")
            {
                Console.WriteLine("\n¡Ya has seleccionado esta carta!\n");
                posicion1 = SolicitarPosicionCarta("primera");
            }

            // Mostrar carta seleccionada
            string carta1 = cartas[posiciones[posicion1 - 1]];
            tablero[posicion1 - 1] = carta1;
            MostrarTablero(tablero);

            // Solicitar posición de la segunda carta
            int posicion2 = SolicitarPosicionCarta("segunda");
            while (tablero[posicion2 - 1] != "🂫" || posicion1 == posicion2)
            {
                Console.WriteLine("\n¡Ya has seleccionado esta carta o es la misma que la primera!\n");
                posicion2 = SolicitarPosicionCarta("segunda");
            }

            // Mostrar carta seleccionada
            string carta2 = cartas[posiciones[posicion2 - 1]];
            tablero[posicion2 - 1] = carta2;
            MostrarTablero(tablero);

            // Incrementar intentos
            intentos++;

            // Verificar si las cartas son iguales
            if (carta1 == carta2)
            {
                Console.WriteLine("\n¡Encontraste un par!\n");
                paresEncontrados++;
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("\n¡Las cartas no coinciden!\n");
                Thread.Sleep(2000);

                // Voltear cartas de nuevo
                tablero[posicion1 - 1] = "🂫";
                tablero[posicion2 - 1] = "🂫";
            }

            // Mostrar mensaje si queda un par por encontrar
            if (5 - paresEncontrados == 1)
            {
                Console.WriteLine("\n¡Queda 1 par por encontrar!\n");
                Thread.Sleep(2000);
            }
        }

        // Mostrar mensaje de pérdida si se supera el límite de intentos
        if (paresEncontrados < 5)
        {
            ReproducirArchivoAudio("/Users/e.r/Desktop/perder.wav");
            Console.WriteLine($"\n\nLo siento, {nombreUsuario}. Has superado el límite de intentos.\n");
            string perdi = @"       
                           __________________________________________________
                           __________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶__________________
                           ______________¶¶¶¶_____________¶¶¶¶¶______________
                           ___________¶¶¶_____________________¶¶¶¶___________
                           ________¶¶¶¶__________________________¶¶¶_________
                           _______¶¶_______________________________¶¶¶_______
                           ______¶¶__________________________________¶¶______
                           ____¶¶_____________________________________¶¶_____
                           ____¶________________________________________¶____
                           ___¶¶________________________________________¶¶___
                           __¶¶_____________¶¶¶__________________________¶___
                           ___¶___________¶¶_____________________________¶¶__
                           ___¶___________¶________________¶¶¶___________¶¶__
                           ___¶_____¶¶_¶¶_¶¶¶¶¶_¶____________¶¶¶__________¶__
                           ___¶_________¶___¶¶¶¶¶¶¶¶¶¶¶¶______¶¶¶_________¶__
                           ___¶¶______¶¶¶¶___¶¶¶¶¶¶¶¶¶¶¶¶¶¶____¶¶¶_¶¶____¶¶¶_
                           ___¶¶____¶¶¶¶¶¶___¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__¶¶¶¶¶¶¶¶__¶¶__
                           ___¶____¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__¶¶¶¶¶¶¶¶¶¶¶___
                           __¶¶___¶¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶¶¶¶¶¶__¶¶¶¶¶¶¶¶¶¶¶¶___
                           ____¶¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶¶¶¶¶¶__¶¶¶¶¶¶¶¶¶¶¶____
                           ______¶¶¶¶¶¶¶___¶¶_____¶¶¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶¶____
                           ______¶__¶¶¶____¶¶¶___________________¶¶¶¶¶¶¶_____
                           _____¶¶________¶¶¶¶¶¶__¶________________¶¶¶_______
                           _____¶¶______¶¶¶____¶¶¶¶______________¶¶¶¶________
                           ______¶¶______¶_______¶¶_________¶¶¶¶¶¶¶¶¶________
                           _______¶¶¶¶¶_______________¶_¶¶¶¶¶¶¶¶¶¶¶¶¶________
                           ___________¶¶¶____¶¶¶¶_¶¶_¶¶¶___¶¶¶¶¶___¶¶________
                           ____________¶¶¶¶¶_¶__¶¶_¶_¶_¶____¶¶_____¶_________
                           _____________¶_____________¶¶_____¶_____¶_________
                           ______________¶¶¶¶¶_¶¶¶¶¶¶________¶¶____¶_________
                           ____________________¶¶¶¶¶¶_________¶____¶_________
                           _____________________¶¶_¶¶_________¶¶___¶¶________
                           ______________________¶¶¶¶¶_________¶____¶________
                           _______________________¶¶¶¶¶_______¶¶____¶¶_______
                           _______________________¶¶¶¶¶______¶_¶_____¶_______
                           _______________________¶_¶¶¶_____¶__¶¶____¶_______
                           _______________________¶¶¶¶¶____¶¶__¶¶___¶________
                           _______________________¶¶¶¶¶__¶¶¶__¶¶___¶_________
                           ________________________¶¶¶¶¶¶¶__¶¶¶___¶¶_________
                           _________________________¶¶_____¶¶¶____¶__________
                           ____________________________¶¶¶¶______¶___________
                           ______________________________¶¶_____¶¶___________
                           _______________________________¶¶¶¶¶¶¶____________
                           __________________________________________________";

            // Animación para mostrar el arte ASCII letra por letra
            foreach (char c in perdi )
            {
                Console.Write(c);
                Thread.Sleep(1); // Pausa para efecto visual
            }
            Console.ReadKey();
        }

        // Mostrar estadísticas del juego si ha encontrado todos los pares
        if (paresEncontrados == 5)
        {
            MostrarEstadisticas(nombreUsuario, intentos);
        }
    }
    
    // Función para mostrar el tablero actualizado
    static void MostrarTablero(string[] tablero)
    {
        Console.Clear();
        Console.WriteLine("Tablero:");
        for (int i = 0; i < tablero.Length; i++)
        {
            Console.Write($"{tablero[i]} ");
            if ((i + 1) % 5 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }

    // Función para solicitar la posición de una carta
    static int SolicitarPosicionCarta(string ordinal)
    {
        Console.Write($"\nSelecciona la {ordinal} carta (1-10): ");
        int posicion;
        while (!int.TryParse(Console.ReadLine(), out posicion) || posicion < 1 || posicion > 10)
        {
            Console.Write("\n\n¡Posición inválida! Inténtalo de nuevo (1-10): ");
        }
        return posicion;
    }

    // Función para mostrar estadísticas finales del juego
    static void MostrarEstadisticas(string nombreUsuario, int intentos)
    {
        ReproducirArchivoAudio("/Users/e.r/Desktop/ganar.wav");
        Console.WriteLine($"¡Felicidades, {nombreUsuario}!");
        Console.WriteLine($"\n\nHas encontrado todos los pares en {intentos} intentos.\n");
        string gane = @"       
                                   _________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__________________
                                   _____________¶¶¶________________¶¶¶_______________
                                   ___________¶¶______________________¶¶¶¶___________
                                   _________¶¶¶__________________________¶¶¶_________
                                   _______¶¶¶___________________¶¶¶¶_______¶¶________
                                   _¶¶¶¶¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶_____¶¶¶__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶__
                                   __¶¶¶¶____¶¶¶¶¶¶¶¶¶_¶¶¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶¶¶¶¶¶___
                                   ___¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶___¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶____¶¶¶____
                                   __¶___¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶______¶¶__¶__
                                   _¶¶___¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶¶¶¶¶¶¶_______¶¶__¶¶__
                                   ¶______¶¶¶¶¶¶¶¶_____¶¶¶___¶¶¶¶¶¶¶¶¶___¶¶¶¶¶____¶__
                                   ¶__________¶¶¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶¶¶¶__¶______¶¶
                                   ¶_______________________________________________¶¶
                                   ¶________¶¶_____________________________________¶¶
                                   ¶______¶¶¶¶_________________________¶¶¶¶________¶¶
                                   ¶_____¶__¶¶_________________________¶¶¶¶________¶¶
                                   ¶_________¶¶¶______________________¶¶___________¶¶
                                   ¶___________¶¶¶__________________¶¶¶____________¶¶
                                   ¶¶____________¶¶¶¶____________¶¶¶¶_____________¶__
                                   _¶¶______________¶¶¶¶¶¶¶¶¶¶¶¶¶¶________________¶__
                                   __¶___________________________________________¶¶__
                                   ___¶¶________________________________________¶¶___
                                   ____¶¶______________________________________¶¶____
                                   _____¶¶___________________________________¶¶______
                                   _______¶¶_______________________________¶¶¶_______
                                   _________¶¶___________________________¶¶¶_________
                                   __________¶¶¶¶_____________________¶¶_____________
                                   ______________¶¶¶¶_____________¶¶¶¶¶______________
                                   ___________________¶¶¶¶¶¶¶¶¶¶¶¶___________________";

        // Animación para mostrar el arte ASCII letra por letra
        foreach (char c in gane )
        {
            Console.Write(c);
            Thread.Sleep(1); // Pausa para efecto visual
        }

        if (intentos == 6)
        {
            Console.WriteLine("\n\n¡Manito, ute' e el mejor en eta' vaina de la memoria!");
        }
        else if (intentos >= 8)
        {
            Console.WriteLine("\n\n¡Buen trabajo en tu memoria!");
        }
        else
        {
            Console.WriteLine("\n\n¡Compai, ute e' un bruto, siga practicando para mejorar su memoria!");
        }

        Console.WriteLine();
    }

    // Mostrar mensaje de despedida al usuario
    static void MostrarDespedida()
    {
        Console.WriteLine("\n\nManito, gracias por jugar el mejor juego que haz jugado en toda tu vida, ¡Cuidate!");
    }
    static void ReproducirArchivoAudio(string ruta)
    {
        try
        {
            Process.Start("afplay", ruta);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n\nError al reproducir el archivo de audio: {ex.Message}");
        }
    }
}