using System;

class Servomotor
{
    // Propiedades del servomotor
    public double PosicionActual { get; set; }
    public double PosicionObjetivo { get; set; }

    // Método para validar una posición entre 0 y 180 grados
    public bool EsPosicionValida(double posicion)
    {
        return posicion >= 0 && posicion <= 180;
    }

    // Método para calcular el desplazamiento absoluto
    public double CalcularDesplazamiento()
    {
        return Math.Abs(PosicionObjetivo - PosicionActual);
    }

    // Método para determinar la dirección del movimiento
    public string DeterminarDireccion()
    {
        if (PosicionObjetivo > PosicionActual)
        {
            return "Movimiento hacia un angulo mayor.";
        }
        else if (PosicionObjetivo < PosicionActual)
        {
            return "Movimiento hacia un angulo menor.";
        }
        else
        {
            return "El servomotor no necesita moverse.";
        }
    }
}

class Program
{
    static void Main()
    {
        Servomotor servo = new Servomotor();

        // Solicitar y validar la posicion actual
        do
        {
            Console.Write("Ingrese la posicion actual del servomotor (0 a 180): ");

            if (!double.TryParse(Console.ReadLine(), out double posicion))
            {
                Console.WriteLine("Entrada invalida. Ingrese un numero.");
                servo.PosicionActual = -1;
            }
            else
            {
                servo.PosicionActual = posicion;
            }

            if (!servo.EsPosicionValida(servo.PosicionActual))
            {
                Console.WriteLine("Error: la posicion debe estar entre 0 y 180 grados.");
            }

        } while (!servo.EsPosicionValida(servo.PosicionActual));

        // Solicitar y validar la posicion objetivo
        do
        {
            Console.Write("Ingrese la posicion objetivo del servomotor (0 a 180): ");

            if (!double.TryParse(Console.ReadLine(), out double posicion))
            {
                Console.WriteLine("Entrada invalida. Ingrese un numero.");
                servo.PosicionObjetivo = -1;
            }
            else
            {
                servo.PosicionObjetivo = posicion;
            }

            if (!servo.EsPosicionValida(servo.PosicionObjetivo))
            {
                Console.WriteLine("Error: la posicion debe estar entre 0 y 180 grados.");
            }

        } while (!servo.EsPosicionValida(servo.PosicionObjetivo));

        // Mostrar los resultados
        Console.WriteLine("\n--- RESULTADOS ---");
        Console.WriteLine("Posicion actual: " + servo.PosicionActual + " grados");
        Console.WriteLine("Posicion objetivo: " + servo.PosicionObjetivo + " grados");
        Console.WriteLine("Desplazamiento: " + servo.CalcularDesplazamiento() + " grados");
        Console.WriteLine(servo.DeterminarDireccion());

        Console.WriteLine("\nPresione una tecla para salir.");
        Console.ReadKey();
    }
}