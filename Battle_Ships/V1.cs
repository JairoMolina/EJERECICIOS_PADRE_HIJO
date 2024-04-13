using System;

class Program
{
    static char[,] TabJug = new char[10, 10];
    static char[,] TabCom = new char[10, 10];
    static Random rnd = new Random();
    static void IniciarTab()
    {
        for (int fila = 0; fila < 10; fila++)
        {
            for (int columna = 0; columna < 10; columna++)
            {
                TabJug[fila, columna] = '~';
                TabCom[fila, columna] = '~';
            }
        }
    }
    static void CrearTab(char[,] tablero)
    {
        Console.Write("   ");
        for (char columna = 'A'; columna <= 'J'; columna++)
        {
            Console.Write(columna + " ");
        }
        Console.WriteLine();

        for (int fila = 0; fila < 10; fila++)
        {
            Console.Write((fila + 1).ToString().PadLeft(2) + " ");
            for (int columna = 0; columna < 10; columna++)
            {
                Console.Write(tablero[fila, columna] + " ");
            }
            Console.WriteLine();
        }
    }
    static void MostrarTab()
    {
        Console.WriteLine("\nTABLERO PROPIO:");
        CrearTab(TabJug);

        Console.WriteLine("\nTABLERO ENEMIGO:");
        CrearTab(TabCom);
    }
    static void JugarBatallaNaval(char[,] tableroJugador, char[,] tableroComputadora)
    {
        Console.WriteLine("¡QUE COMIENCE LA BATALLA NAVAL!");

        bool jugadorGana = false;
        bool computadoraGana = false;

        while (!jugadorGana && !computadoraGana)
        {
            // Turno del jugador
            Console.WriteLine("\nTURNO DEL JUGADOR:");
            RealizarDisparo(tableroComputadora);

            // Verificar si el jugador ha ganado
            if (TodosLosBarcosHundidos(tableroComputadora))
            {
                jugadorGana = true;
                break;
            }

            // Turno de la computadora
            Console.WriteLine("\nTURNO DE LA COMPUTADORA:");
            RealizarDisparoComputadora(tableroJugador);

            // Verificar si la computadora ha ganado
            if (TodosLosBarcosHundidos(tableroJugador))
            {
                computadoraGana = true;
                break;
            }
        }

        // Mostrar resultado del juego
        if (jugadorGana)
        {
            Console.WriteLine("\n¡FELICIDADES! ¡HAS DERROTADO A LA COMPUTADORA!");
        }
        else if (computadoraGana)
        {
            Console.WriteLine("\n¡HAS SIDO DERROTADO POR LA COMPUTADORA!");
        }
    }
    static void RealizarDisparo(char[,] tablero)
    {
        Console.Write("Ingresa la fila para disparar (1-10): ");
        int fila = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.Write("Ingresa la columna para disparar (A-J): ");
        char columna = char.ToUpper(Console.ReadKey().KeyChar);
        int columnaIndex = columna - 'A';

        if (tablero[fila, columnaIndex] != '~' && tablero[fila, columnaIndex] != 'o')
        {
            Console.WriteLine("\n¡ACIERTO!");
            tablero[fila, columnaIndex] = 'x';
        }
        else
        {
            Console.WriteLine("\n¡FALLASTE!");
            tablero[fila, columnaIndex] = 'o';
        }

        CrearTab(TabJug);
    }

    static void RealizarDisparoComputadora(char[,] tablero)
    {
        Random rnd = new Random();
        int fila = rnd.Next(0, tablero.GetLength(0));
        int columna = rnd.Next(0, tablero.GetLength(1));

        if (tablero[fila, columna] != '~' && tablero[fila, columna] != 'o')
        {
            Console.WriteLine($"La computadora ha acertado en la fila {fila + 1}, columna {(char)('A' + columna)}!");
            tablero[fila, columna] = 'x';
        }
        else
        {
            Console.WriteLine($"La computadora ha fallado en la fila {fila + 1}, columna {(char)('A' + columna)}.");
            tablero[fila, columna] = 'o';
        }

        CrearTab(TabJug);
    }

    static bool TodosLosBarcosHundidos(char[,] tablero)
    {
        foreach (char c in tablero)
        {
            if (c == '▓')
            {
                return false;
            }
        }
        return true;
    }

    static void Menu()
    {
        Console.WriteLine("\nORGANIZA TUS BARCOS CAPITAN\n");
        CrearTab(TabJug);

        Console.WriteLine("\nBARCOS DISPONIBLES:");
        Console.WriteLine("1. LANCHA █ (1x1)");
        Console.WriteLine("2. SUBMARINO ▓▓ (2x1)");
        Console.WriteLine("3. BUQUE ███ (3x1)");
        Console.WriteLine("4. PORTAAVIONES ████ (4x1)");

        ColocarBarcoJug(TabJug, "LANCHA");
        CrearTab(TabJug);
        ColocarBarcoJug(TabJug, "SUBMARINO");
        CrearTab(TabJug);
        ColocarBarcoJug(TabJug, "BUQUE");
        CrearTab(TabJug);
        ColocarBarcoJug(TabJug, "PORTAAVIONES");
        CrearTab(TabJug);

        Console.WriteLine("¡LISTO PARA COMENZAR LA BATALLA!");
        Thread.Sleep(3000);
        Console.Clear();
    }
    static void ColocarBarcoJug(char[,] Tab, string Barco)
    {
        int Tamaño = 1;
        switch (Barco)
        {
            case "VELERO":
                Tamaño = 1;
                break;
            case "SUBMARINO":
                Tamaño = 2;
                break;
            case "BUQUE":
                Tamaño = 3;
                break;
            case "PORTAAVIONES":
                Tamaño = 4;
                break;
        }

        bool colocado = false;

        while (!colocado)
        {
            Console.WriteLine($"\nCOLOCA UN {Barco} DE {Tamaño}x1.");

            Console.Write("INGRESA LA FILA (1-10): ");
            int Fila = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("INGRESA LA COLUMNA (A-J): ");
            char ColumnaInicio = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("INGRESA LA ORIENTACIÓN (H - Horizontal, V - Vertical): ");
            char Orientacion = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            int ColumnaInicioIndex = ColumnaInicio - 'A';

            if (Orientacion != 'H' && Orientacion != 'V')
            {
                Console.WriteLine("\nORIENTACIÓN INVÁLIDA");
                continue;
            }

            if (Fila < 0 || Fila >= Tab.GetLength(0) || ColumnaInicioIndex < 0 || ColumnaInicioIndex >= Tab.GetLength(1))
            {
                Console.WriteLine("\nFUERA DEL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            if (Orientacion == 'H' && ColumnaInicioIndex + Tamaño > Tab.GetLength(1))
            {
                Console.WriteLine("\nSIN ESPACIO EN EL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }
            else if (Orientacion == 'V' && Fila + Tamaño > Tab.GetLength(0))
            {
                Console.WriteLine("\nSIN ESPACIO EN EL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            bool HayBarco = false;
            if (Orientacion == 'H')
            {
                for (int Columna = ColumnaInicioIndex; Columna < ColumnaInicioIndex + Tamaño; Columna++)
                {
                    if (Tab[Fila, Columna] != '~')
                    {
                        HayBarco = true;
                        break;
                    }
                }
            }

            else
            {
                for (int FilaIndice = Fila; FilaIndice < Fila + Tamaño; FilaIndice++)
                {
                    if (Tab[FilaIndice, ColumnaInicioIndex] != '~')
                    {
                        HayBarco = true;
                        break;
                    }
                }
            }

            if (HayBarco)
            {
                Console.WriteLine("¡YA HAY UN BARCO EN ESA POSICIÓN! INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            if (Orientacion == 'H')
            {
                for (int Columna = ColumnaInicioIndex; Columna < ColumnaInicioIndex + Tamaño; Columna++)
                {
                    Tab[Fila, Columna] = '▓';
                }
            }
            else
            {
                for (int FilaIndice = Fila; FilaIndice < Fila + Tamaño; FilaIndice++)
                {
                    Tab[FilaIndice, ColumnaInicioIndex] = '▓';
                }
            }
            colocado = true;
        }
    }
    static void ColocarBarcoCom(char[,] Tab)
    {
        Console.WriteLine("LA COMPUTADORA ESTÁ COLOCANDO SUS BARCOS...");
        Thread.Sleep(2000);

        ColocarBarcoComp(Tab, "LANCHA");
        ColocarBarcoComp(Tab, "SUBMARINO");
        ColocarBarcoComp(Tab, "BUQUE");
        ColocarBarcoComp(Tab, "PORTAAVIONES");
    }
    static void ColocarBarcoComp(char[,] Tab, string Barco)
    {
        int Tamaño = 0;
        switch (Barco)
        {
            case "LANCHA":
                Tamaño = 1;
                break;
            case "SUBMARINO":
                Tamaño = 2;
                break;
            case "BUQUE":
                Tamaño = 3;
                break;
            case "PORTAAVIONES":
                Tamaño = 4;
                break;
        }

        bool colocado = false;

        while (!colocado)
        {
            int filaInicio = rnd.Next(0, Tab.GetLength(0));
            int columnaInicio = rnd.Next(0, Tab.GetLength(1));
            char orientacion = rnd.Next(2) == 0 ? 'H' : 'V';

            if (orientacion == 'H' && columnaInicio + Tamaño > Tab.GetLength(1))
            {
                continue;
            }
            else if (orientacion == 'V' && filaInicio + Tamaño > Tab.GetLength(0))
            {
                continue;
            }

            bool hayBarco = false;
            if (orientacion == 'H')
            {
                for (int columna = columnaInicio; columna < columnaInicio + Tamaño; columna++)
                {
                    if (Tab[filaInicio, columna] != '~')
                    {
                        hayBarco = true;
                        break;
                    }
                }
            }
            else
            {
                for (int fila = filaInicio; fila < filaInicio + Tamaño; fila++)
                {
                    if (Tab[fila, columnaInicio] != '~')
                    {
                        hayBarco = true;
                        break;
                    }
                }
            }

            if (hayBarco)
            {
                continue;
            }

            if (orientacion == 'H')
            {
                for (int columna = columnaInicio; columna < columnaInicio + Tamaño; columna++)
                {
                    Tab[filaInicio, columna] = '▓';
                }
            }
            else
            {
                for (int fila = filaInicio; fila < filaInicio + Tamaño; fila++)
                {
                    Tab[fila, columnaInicio] = '▓';
                }
            }
            colocado = true;
        }
    }

    

    static void Main()
    {
        Console.WriteLine("~~~~~~~~~~ BATTLE SHIPS ~~~~~~~~~~");
        Console.Write("Por favor, ingresa tu nombre: ");
        string Jugador = Console.ReadLine().ToUpper();

        Console.Clear();

        Menu(Jugador);
    }

    static void Menu(string Jugador)
    {
        bool Salir = false;

        while (!Salir)
        {
            Console.WriteLine("~~~~~~~~~~ BATTLE SHIPS ~~~~~~~~~~");
            Console.WriteLine($"BIENVENIDO, {Jugador}!\nLISTOS PARA LA BATALLA CAPITAN!!!");
            Console.WriteLine("\n~~~~~~~~ MENÚ DE ABORDAJE ~~~~~~~~");
            Console.WriteLine("1. JUGAR");
            Console.WriteLine("2. AJUSTES");
            Console.WriteLine("3. CREDITOS");
            Console.WriteLine("4. SALIDA");

            Console.Write("\nSelecciona una opción: ");
            string opcion = Console.ReadLine();

            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    IniciarTab();
                    Console.Clear();
                    JugarBatallaNaval(TabJug, TabCom);

                    break;
                case "2":
                    Console.WriteLine("Ajustes: Aquí podrás configurar opciones del juego.");
                    // Llamar a la función para mostrar ajustes
                    break;
                case "3":
                    Console.WriteLine("Créditos: Desarrollado por [tu nombre aquí].");
                    // Llamar a la función para mostrar créditos
                    break;
                case "4":
                    Console.WriteLine("Gracias por jugar. ¡Hasta luego, " + Jugador + "!");
                    Salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
                    break;
            }
        }
    }
}