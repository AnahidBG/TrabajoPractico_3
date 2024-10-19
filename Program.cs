using System;

class Program
{
    static int[][] asientos = new int[20][];
    static bool vuelosCreado = false;

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("------BIENVENIDOS A LA AEROLINEA------");
            Console.WriteLine("¿Qué queres hacer?:" +
                "\n1) Crear un vuelo." +
                "\n2) Reservar un asiento." +
                "\n3) Cancelar una reserva." +
                "\n4) Mostrar estado del vuelo." +
                "\n5) Mostrar cantidad de asientos disponibles y ocupados." +
                "\n6) Buscar un asiento." +
                "\n7) Salir.");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearVuelo();
                    break;
                case 2:
                    ReservarAsiento();
                    break;
                case 3:
                    CancelarReserva();
                    break;
                case 4:
                    MostrarEstadoVuelo();
                    break;
                case 5:
                    MostrarCantidadAsientos();
                    break;
                case 6:
                    BuscarAsiento();
                    break;
                case 7:
                    Console.WriteLine("Saliste del sistema.");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        Console.ReadKey();
    }

    //Crear un vuelo (inicialmente con todos los asientos vacíos). Cada vuelo tiene 60 asientos. 

    static void CrearVuelo()
    {
        if (!vuelosCreado)
        {

            for (int i = 0; i < asientos.Length; i++)
            {
                asientos[i] = new int[3];
            }
            vuelosCreado = true;
            Console.WriteLine("¡Tu vuelo ya se creó! Tenes 60 asientos disponibles.");
        }
        else
        {
            Console.WriteLine("El vuelo ya se creó.");
        }
    }
    //Reservar un asiento. Si está disponible (0) lo marca como ocupado (1).
    static void ReservarAsiento()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Console.WriteLine("Ingrese el número de fila (1-20):");
        int fila = int.Parse(Console.ReadLine()) - 1; //El "-1" ajusta el indice a 0
        Console.WriteLine("Ingrese el número de asiento (1-3):");
        int columna = int.Parse(Console.ReadLine()) - 1;

        if (fila >= 0 && fila < 20 && columna >= 0 && columna < 3)
        {
            if (asientos[fila][columna] == 0)
            {
                asientos[fila][columna] = 1;
                Console.WriteLine("¡Asiento reservado con éxito!");
            }
            else
            {
                Console.WriteLine("Asiento ocupado, seleccione otro.");
            }
        }
        else
        {
            Console.WriteLine("Número de fila o asiento no válido.");
        }

    }

    //Cancelar una reserva. El vuelo vuelve a estar disponible (0)
    static void CancelarReserva()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Console.WriteLine("Ingrese el número de fila (1-20):");
        int fila = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine("Ingrese el número de asiento (1-3):");
        int columna = int.Parse(Console.ReadLine()) - 1;

        if (fila >= 0 && fila < 20 && columna >= 0 && columna < 3)
        {
            if (asientos[fila][columna] == 1)
            {
                asientos[fila][columna] = 0;
                Console.WriteLine("Cancelaste la reserva.");
            }
            else
            {
                Console.WriteLine("El asiento no está reservado.");
            }
        }
        else
        {
            Console.WriteLine("Número de fila o asiento no válido.");
        }
    }

    //Mostrar el estado actual del vuelo, mostrando todos los asientos disponibles y ocupados.
    static void MostrarEstadoVuelo()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Console.WriteLine("Estado del vuelo:");

        for (int i = 0; i < asientos.Length; i++)
        {
            for (int j = 0; j < asientos[i].Length; j++)
            {
                if (asientos[i][j] == 0)
                {
                    Console.Write(asientos[i][j] + " Disponible\t");// Imprime el elemento y una tabulación
                }
                else
                {
                    Console.Write(asientos[i][j] + " Ocupado\t");
                }

            }
            Console.WriteLine(); // Salto de línea
        }

    }

    //Mostrar la cantidad de asientos disponibles y ocupados en el vuelo
    static void MostrarCantidadAsientos()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        int contadorDisponibles = 0, contadorOcupados = 0;
        for (int i = 0; i < asientos.Length; i++)
        {
            for (int j = 0; j < asientos[i].Length; j++)
            {
                if (asientos[i][j] == 0)
                {
                    contadorDisponibles++;
                }
                else
                {
                    contadorOcupados++;
                }
            }
        }
        Console.WriteLine("Hay " + contadorDisponibles + " asientos disponibles y " + contadorOcupados + " asientos ocupados.");
    }

    //Buscar un asiento en particular e indicar si el mismo está disponible
    static void BuscarAsiento()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Console.WriteLine("Ingrese el número de fila (1-20):");
        int fila = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine("Ingrese el número de asiento (1-3):");
        int columna = int.Parse(Console.ReadLine()) - 1;

        if (fila >= 0 && fila < 20 && columna >= 0 && columna < 3)
        {
            if (asientos[fila][columna] == 0)
            {
                Console.WriteLine("El estado del asiento " + (columna + 1) + " en la fila " + (fila + 1) + " esta disponible.");
            }
            else
            {
                Console.WriteLine("El estado del asiento " + (columna + 1) + " en la fila " + (fila + 1) + " esta ocupado.");
            }
        }
        else
        {
            Console.WriteLine("Número de fila o asiento no válido.");
        }
    }
}