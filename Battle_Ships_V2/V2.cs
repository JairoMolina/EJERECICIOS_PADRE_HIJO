using System;
class Program
{
    static void Main()
    {
        bool continuar = true;
        while (continuar){
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~ BATTLE SHIPS ~~~~~~~~~~");
            Console.WriteLine($"BIENVENIDO, {Player}! \nLISTOS PARA LA BATALLA!!!");
            Console.WriteLine("\n~~~~~~~~ MENÚ DE ABORDAJE ~~~~~~~~");
            Console.WriteLine("1. JUGAR");
            Console.WriteLine("2. AJUSTES");
            Console.WriteLine("3. CREDITOS");
            Console.WriteLine("4. SALIDA");
            Console.Write("\nSELECCIONE UNA OPCION: ");
            string Opción = Console.ReadLine();

            Console.Clear();

            switch (Opción){
                case "1":
                    Console.Clear();
                    CrearTab();
                    Barcos();
                    BarcosCPU();

                    while (true){
                        DisparoPlay();
                        if (Victoria(TabCPU)) {
                            Console.WriteLine("¡HAS DERRIBADO TODOS LOS BARCOS ENEMIGOS! \n¡HAS GANADO LA BATALLA!");
                            break;
                        }

                        DisparoCPU();
                        if (Victoria(TabPlay)){
                            Console.WriteLine($"¡La {CPU} HA UNDIDO TODOS TUS BARCOS! \n¡HAS PERDIDO LA BATALLA!");
                            break;
                        }

                        Console.Clear();
                    }

                    break;
                case "2":
                    Console.Clear();
                    Ajustes();

                    break;
                case "3":
                    Console.WriteLine("~~~~~~~~~~ CREDITOS ~~~~~~~~~~");
                    Console.WriteLine("JUEGO DESARROLADO POR 4D&N");
                    Console.WriteLine("By: JAIRO LEONEL MOLINA");
                    Console.WriteLine("\nAGRADECIMIENTOS ESPECIALES");
                    Console.WriteLine("- MIS AMIGOS DESARROLLADORES");
                    Console.WriteLine("- MIS DESVELOS");
                    Console.WriteLine("- MIS GANAS DE APRENDER");
                    Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
                    Console.ReadKey();

                    break;
                case "4":
                    Console.WriteLine("~~~~~~~~~~ SALIDA ~~~~~~~~~~");
                    Console.WriteLine("MUCHAS GRACIAS POR PROBAR ESTE JUEGO. \n¡HASTA LUEGO, " + Player + "!");
                    continuar = false;

                    break;
                default:

                   Console.WriteLine("OPCION INVALIDA");
                    break;
            }
        }
    }

    static string Player = "CAPITAN";
    static string CPU = "CPU";
    static char[,] TabPlay = new char[10, 10];
    static char[,] TabPlayDisp = new char[10, 10];
    static char[,] TabCPU = new char[10, 10];

    static void CrearTab()
    {
        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++){
                TabPlay[i, j] = '~';
            }
        }

        for (int i = 0; i < 10; i++){
            for (int j = 0; j < 10; j++){
                TabCPU[i, j] = '~';
            }
        }

        for (int fila = 0; fila < 10; fila++){
            for (int columna = 0; columna < 10; columna++){
                TabPlayDisp[fila, columna] = '~';
            }
        }
    }

    static void MostrarTab(char[,] tablero)
    {
        Console.Write("   ");
        for (char columna = 'A'; columna <= 'J'; columna++){
            Console.Write(columna + " ");
        }

        Console.WriteLine();

        for (int fila = 0; fila < 10; fila++){
            Console.Write((fila + 1).ToString().PadLeft(2) + " ");
            for (int columna = 0; columna < 10; columna++){
                if (tablero[fila, columna] == '~' || tablero[fila, columna] == 'O'){
                    Console.Write(tablero[fila, columna] + " ");
                }
                else{
                    Console.Write(tablero[fila, columna] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    static void Barcos()
    {
        Console.WriteLine($"~~~~ ORGANIZA TUS BARCOS {Player} ~~~~\n");
        MostrarTab(TabPlay);

        Console.WriteLine("\nBARCOS DISPONIBLES:");
        Console.WriteLine("1. LANCHA       ■    (1x1)");
        Console.WriteLine("2. SUBMARINO    ■■   (2x1)");
        Console.WriteLine("3. BUQUE        ■■■  (3x1)");
        Console.WriteLine("4. PORTAAVIONES ■■■■ (4x1)");

        ColocarBarcosPlay(TabPlay, "LANCHA");
        MostrarTab(TabPlay);
        ColocarBarcosPlay(TabPlay, "SUBMARINO");
        MostrarTab(TabPlay);
        ColocarBarcosPlay(TabPlay, "BUQUE");
        MostrarTab(TabPlay);
        ColocarBarcosPlay(TabPlay, "PORTAAVIONES");
        MostrarTab(TabPlay);

        Console.WriteLine($"\n¡LISTO PARA COMENZAR LA {Player}");
        Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
        Console.ReadKey();
        Console.Clear();
    }
    
    static void ColocarBarcosPlay(char[,] Tab, string Barco)
    {
        int Tamaño = 1;
        switch (Barco){
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

        while (!colocado){
            Console.WriteLine($"\nCOLOCA UN {Barco} DE {Tamaño}x1\n");

            Console.Write("INGRESA LA FILA (1-10): ");
            int Fila = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("INGRESA LA COLUMNA (A-J): ");
            char ColumnaInicio = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.Write("INGRESA LA ORIENTACIÓN \n(H = HORIZONTAL, V = VERTICAL): ");
            char Orientacion = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            int ColumnaInicioIndex = ColumnaInicio - 'A';

            if (Orientacion != 'H' && Orientacion != 'V'){
                Console.WriteLine("\nORIENTACIÓN INVÁLIDA");
                continue;
            }

            if (Fila < 0 || Fila >= Tab.GetLength(0) || ColumnaInicioIndex < 0 || ColumnaInicioIndex >= Tab.GetLength(1)){
                Console.WriteLine("\nFUERA DEL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            if (Orientacion == 'H' && ColumnaInicioIndex + Tamaño > Tab.GetLength(1)){
                Console.WriteLine("\nSIN ESPACIO EN EL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }
            else if (Orientacion == 'V' && Fila + Tamaño > Tab.GetLength(0)){
                Console.WriteLine("\nSIN ESPACIO EN EL TABLERO. INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            bool HayBarco = false;
            if (Orientacion == 'H'){
                for (int Columna = ColumnaInicioIndex; Columna < ColumnaInicioIndex + Tamaño; Columna++){
                    if (Tab[Fila, Columna] != '~'){
                        HayBarco = true;
                        break;
                    }
                }
            }

            else{
                for (int FilaIndice = Fila; FilaIndice < Fila + Tamaño; FilaIndice++){
                    if (Tab[FilaIndice, ColumnaInicioIndex] != '~'){
                        HayBarco = true;
                        break;
                    }
                }
            }

            if (HayBarco){
                Console.WriteLine("\n¡YA HAY UN BARCO EN ESA POSICIÓN! INGRESA UNA POSICIÓN VÁLIDA.");
                continue;
            }

            if (Orientacion == 'H'){
                for (int Columna = ColumnaInicioIndex; Columna < ColumnaInicioIndex + Tamaño; Columna++){
                    Tab[Fila, Columna] = '■';
                }
            }

            else{
                for (int FilaIndice = Fila; FilaIndice < Fila + Tamaño; FilaIndice++){
                    Tab[FilaIndice, ColumnaInicioIndex] = '■';
                }
            }
            colocado = true;
            Console.Clear();
        }
    }

    static void BarcosCPU()
    {
        Random rnd = new Random();

        ColocarBarcosCPU(TabCPU, rnd, "LANCHA");
        ColocarBarcosCPU(TabCPU, rnd, "SUBMARINO");
        ColocarBarcosCPU(TabCPU, rnd, "BUQUE");
        ColocarBarcosCPU(TabCPU, rnd, "PORTAAVIONES");

        Console.WriteLine($"{CPU} ESTA COLOCANDO SUS BARCOS...");
        Thread.Sleep(2500);
        Console.Clear();
    }

    static void ColocarBarcosCPU(char[,] tablero, Random rnd, string barco)
    {
        int tamaño = 0;
        switch (barco){
            case "LANCHA":
                tamaño = 1;
                break;
            case "SUBMARINO":
                tamaño = 2;
                break;
            case "BUQUE":
                tamaño = 3;
                break;
            case "PORTAAVIONES":
                tamaño = 4;
                break;
        }

        bool colocado = false;

        while (!colocado){
            int fila = rnd.Next(10);
            int columna = rnd.Next(10);
            int orientacion = rnd.Next(2);

            if (orientacion == 0 && columna + tamaño <= 10){
                bool ocupado = false;
                for (int i = columna; i < columna + tamaño; i++){
                    if (tablero[fila, i] != '~')
                    {
                        ocupado = true;
                        break;
                    }
                }

                if (!ocupado){
                    for (int i = columna; i < columna + tamaño; i++){
                        tablero[fila, i] = '■';
                    }
                    colocado = true;
                }
            }

            else if (orientacion == 1 && fila + tamaño <= 10){
                bool ocupado = false;
                for (int i = fila; i < fila + tamaño; i++){
                    if (tablero[i, columna] != '~'){
                        ocupado = true;
                        break;
                    }
                }

                if (!ocupado){
                    for (int i = fila; i < fila + tamaño; i++){
                        tablero[i, columna] = '■';
                    }
                    colocado = true;
                }
            }
        }
    }
    static void DisparoPlay()
    {
        Console.Clear();
        Console.WriteLine($"~~~~~~ ¡TU TURNO {Player}! ~~~~~~");
        MostrarTab(TabPlayDisp);
        Console.Write("\nINGRESA LA FILA A DISPARAR (1-10): ");
        int fila = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Write("INGRESA LA COLUMNA A DISPARAR (A-J): ");
        char columna = char.ToUpper(Console.ReadKey().KeyChar);
        int columnaIndex = columna - 'A';
        Console.WriteLine();

        if (TabCPU[fila, columnaIndex] == '■')
        {
            Console.WriteLine("\n¡BARCO IMPACTADO!\n");
            TabPlayDisp[fila, columnaIndex] = 'X';
            TabCPU[fila, columnaIndex] = 'X';
        }
        else
        {
            Console.WriteLine("\n¡HAS FALLADO EL DISPARO!\n");
            TabPlayDisp[fila, columnaIndex] = 'O';
        }
        MostrarTab(TabPlayDisp);
        Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
        Console.ReadKey();
        Console.Clear();
    }

    static void DisparoCPU()
    {
        Console.WriteLine($"~~~~~~ !TURNO DE {CPU}¡ ~~~~~~");
        Thread.Sleep(1000);
        Random rnd = new Random();
        int fila = rnd.Next(10);
        int columna = rnd.Next(10);

        if (TabPlay[fila, columna] != '~'){
            return;
        }

        if (TabPlay[fila, columna] == '■'){
            Console.WriteLine($"\n{CPU} HA ACERTADO EN {Coords(fila, columna)}\n");
            TabPlay[fila, columna] = 'X';
        }
        else{
            Console.WriteLine($"\n{CPU} HA FALLADO EN {Coords(fila, columna)}\n");
            TabPlay[fila, columna] = 'O';
        }
        
        MostrarTab(TabPlay);
        Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
        Console.ReadKey();
        Console.Clear();
    }

    static string Coords(int fila, int columna)
    {
        return $"{(char)(columna + 'A')}{fila + 1}";
    }

    static bool Victoria(char[,] tablero)
    {
        foreach (var cell in tablero){
            if (cell == '■'){
                return false;
            }
        }
        return true;
    }
    static void Ajustes()
    {
        Console.WriteLine("~~~~~~~~~~ AJUSTES ~~~~~~~~~~");
        Console.WriteLine("1. CAMBIAR NOMBRE DE JUGADOR");
        Console.WriteLine("2. CAMBIAR NOMBRE DE CPU");
        Console.WriteLine("3. VOLVER A MENU PRINCIPAL");
        Console.Write("\nSELECCIONA UNA OPCION: ");
        string OpciónAjus = Console.ReadLine();

        switch (OpciónAjus)
        {
            case "1":
                Console.Write("INGRESA TU NUEVO NOMBRE: ");
                Player = Console.ReadLine().ToUpper();
                Console.WriteLine("\nNOMBRE CAMBIADO CON EXITO");
                Console.WriteLine($"TU NUEVO NOMBRE ES: {Player}");
                Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
                Console.ReadKey();
                Console.Clear();
                Ajustes();
                break;

            case "2":
                Console.Write($"INGRESA EL NUEVO NOMBRE DE {CPU}: ");
                CPU = Console.ReadLine().ToUpper();
                Console.WriteLine("\nNOMBRE CAMBIADO CON EXITO");
                Console.WriteLine($"EL NUEVO NOMBRE DE TU ENEMIGO AHORA ES: {CPU}");
                Console.WriteLine("\nPRESIONA CUALQUIER TECLA PARA CONTINUAR...");
                Console.ReadKey();
                Console.Clear();
                Ajustes();
                break;

            case "3":
                Console.Clear();
                Main();
                break;

            default:
                Console.WriteLine("OPCION INVALIDA.");
                break;
        }
    }
}