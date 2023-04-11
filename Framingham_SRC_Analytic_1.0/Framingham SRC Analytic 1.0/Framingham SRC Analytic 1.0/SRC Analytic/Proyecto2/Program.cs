using System;
using System.Collections.Generic;

namespace SRC_Analytic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definir array 2x20
            string[,] listaDiabeticos = { { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" },
                                          { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" } };

            string[,] listaNoDiabeticos = { { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" },
                                            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" } };

            //Pedir datos
            Console.WriteLine("¿Tiene Diabetes? (S/N)");
            string diabetes = Console.ReadLine().ToUpper();

            while (diabetes != "S" && diabetes != "N")
            {
                Console.WriteLine("El valor ingresado no es válido. Por favor, ingrese S o N.");
                diabetes = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("¿Hombre o Mujer? (H/M)");
            string genero = Console.ReadLine().ToUpper(); ;

            while (genero != "H" && genero != "M")
            {
                Console.WriteLine("El genero especificado no es válido. Por favor, ingrese H o M.");
                genero = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("¿Fuma? (S/N)");
            string fuma = Console.ReadLine().ToUpper(); ;

            while (fuma != "S" && fuma != "N")
            {
                Console.WriteLine("El valor ingresado no es válido. Por favor, ingrese S o N.");
                fuma = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Ingrese la edad");
            int edad;

            while (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.WriteLine("El valor ingresado no es válido. Por favor, ingrese un número entero.");
            }

            //Se crea la lista con rangos de valores para el colesterol
            List<Tuple<decimal, decimal>> rangosColesterol = new List<Tuple<decimal, decimal>> {
            Tuple.Create(0m, 160m),
            Tuple.Create(161m, 219m),
            Tuple.Create(220m, 259m),
            Tuple.Create(260m, 279m),
            Tuple.Create(280m, decimal.MaxValue)
            };

            // Pedir dato del colesterol
            Console.WriteLine("Ingrese el nivel de colesterol (mgDl)");
            decimal colesterol = Convert.ToDecimal(Console.ReadLine());

            // Buscar la posición del valor de colesterol en la lista de rangos
            int posicionColesterol = -1;

            for (int i = 0; i < rangosColesterol.Count; i++)
            {
                if (colesterol >= rangosColesterol[i].Item1 && colesterol <= rangosColesterol[i].Item2)
                {
                    posicionColesterol = i;
                    break;
                }
            }

            //Se crea la lista con rangos de valores para la presion
            List<Tuple<decimal, decimal>> rangosPresion = new List<Tuple<decimal, decimal>> {
            Tuple.Create(160m, decimal.MaxValue),
            Tuple.Create(140m, 159m),
            Tuple.Create(130m, 139m),
            Tuple.Create(120m, 129m),
            Tuple.Create(0m, 119m)
            };

            // Pedir dato del colesterol
            Console.WriteLine("Ingrese la presion arterial sistolica (mmHg)");
            decimal presion = Convert.ToDecimal(Console.ReadLine());

            // Buscar la posición del valor de presion en la lista de rangos
            int posicionPresion = -1;

            for (int i = 0; i < rangosPresion.Count; i++)
            {
                if (presion >= rangosPresion[i].Item1 && presion <= rangosPresion[i].Item2)
                {
                    posicionPresion = i;
                    break;
                }
            }



            // Inicio de clasificacion de tabla segun filtro de datos
            string valorX = "";
            string valorY = "";

            if (diabetes == "S")
            {
                if (genero == "H")
                {
                    if (fuma == "N")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaDiabeticos[0, posicionColesterol];
                                valorY = listaDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaDiabeticos[0, posicionColesterol];
                                valorY = listaDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaDiabeticos[0, posicionColesterol];
                                valorY = listaDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaDiabeticos[0, posicionColesterol];
                                valorY = listaDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                    if (fuma == "S")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaDiabeticos[0, posicionColesterol + 5];
                                valorY = listaDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaDiabeticos[0, posicionColesterol + 5];
                                valorY = listaDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaDiabeticos[0, posicionColesterol + 5];
                                valorY = listaDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaDiabeticos[0, posicionColesterol + 5];
                                valorY = listaDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                }
                if (genero == "M")
                {
                    if (fuma == "N")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaDiabeticos[0, posicionColesterol + 10];
                                valorY = listaDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaDiabeticos[0, posicionColesterol + 10];
                                valorY = listaDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaDiabeticos[0, posicionColesterol + 10];
                                valorY = listaDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaDiabeticos[0, posicionColesterol + 10];
                                valorY = listaDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                    if (fuma == "S")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaDiabeticos[0, posicionColesterol + 15];
                                valorY = listaDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaDiabeticos[0, posicionColesterol + 15];
                                valorY = listaDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaDiabeticos[0, posicionColesterol + 15];
                                valorY = listaDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaDiabeticos[0, posicionColesterol + 15];
                                valorY = listaDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                }
            }

            else if (diabetes == "N")
            {
                if (genero == "H")
                {
                    if (fuma == "N")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaNoDiabeticos[0, posicionColesterol];
                                valorY = listaNoDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaNoDiabeticos[0, posicionColesterol];
                                valorY = listaNoDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaNoDiabeticos[0, posicionColesterol];
                                valorY = listaNoDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaNoDiabeticos[0, posicionColesterol];
                                valorY = listaNoDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                    else if (fuma == "S")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 5];
                                valorY = listaNoDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 5];
                                valorY = listaNoDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 5];
                                valorY = listaNoDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 5];
                                valorY = listaNoDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                }
                else if (genero == "M")
                {
                    if (fuma == "N")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 10];
                                valorY = listaNoDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 10];
                                valorY = listaNoDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 10];
                                valorY = listaNoDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 10];
                                valorY = listaNoDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                    else if (fuma == "S")
                    {
                        switch (edad)
                        {
                            case int e when e >= 65 && e <= 74:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 15];
                                valorY = listaNoDiabeticos[1, posicionPresion];
                                break;
                            case int e when e >= 55 && e <= 64:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 15];
                                valorY = listaNoDiabeticos[1, posicionPresion + 5];
                                break;
                            case int e when e >= 45 && e <= 54:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 15];
                                valorY = listaNoDiabeticos[1, posicionPresion + 10];
                                break;
                            case int e when e >= 35 && e <= 44:
                                valorX = listaNoDiabeticos[0, posicionColesterol + 15];
                                valorY = listaNoDiabeticos[1, posicionPresion + 15];
                                break;
                        }
                    }
                }
            }
            string coordenada = valorX + "," + valorY;
            Console.WriteLine("\nCoordenada obtenida: " + coordenada);
            Console.ReadLine();
        }
    }
}