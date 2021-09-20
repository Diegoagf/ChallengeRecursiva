using CsvHelper;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using ChallengeRecursiva.Models;
using System.Collections.Generic;

namespace ChallengeRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion, path, menu;           

            try
            {
                
                path = Directory.GetCurrentDirectory() + "\\socios.csv";
                //string pathenv = Environment.GetEnvironmentVariable("Path");
                

                //Lectura y serialización del archivo
                List<SociosModel> socios = Helpers.Helper.leerArchivo(path);

                menu = "Seleccione una opción\n" +
                    "\n1.-Cantidad de personas" +
                    "\n2.-Promedio de edad de socios de Racing" +
                    "\n3.-100 primeras personas casadas con estudios universitarios" +
                    "\n4.-Los 5 nombres mas comunes de Hinchas de River" +
                    "\n5.-Listado por Equipos" +
                    "\n6.-Salir";

                Console.WriteLine(menu);

                opcion = Console.ReadLine();

                Console.Clear();

                //Opciones de consola
                switch (opcion)
                {
                    case "1":
                        string Total = socios.Count.ToString();
                        Console.WriteLine("La Cantidad de personas es " + Total);
                        break;


                    case "2":
                        var promedio = Helpers.Helper.Consultas(opcion, socios);
                        Console.WriteLine("El Promedio de la edad de socios de Racing es " + promedio[0]);
                        break;

                    case "3":
                        var ListaSocios = Helpers.Helper.Consultas(opcion, socios);
                        Console.WriteLine("Las primeras 100 personas casadas con estudios Universitarios son:\n");
                        foreach (var item in ListaSocios)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "4":
                        var nombres = Helpers.Helper.Consultas(opcion, socios);
                        Console.WriteLine("Los 5 nombres mas comunes de River son\n");
                        foreach (var item in nombres)
                        {
                            Console.WriteLine(item);
                        }
                        break;


                    case "5":
                        var equipos = Helpers.Helper.Consultas(opcion, socios);
                        Console.WriteLine("Equipos\n");
                        foreach (var item in equipos)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "6":
                        break;

                    default:
                        Console.WriteLine("Opción Invalida");
                        break;

                }

                Console.WriteLine("\nPresiona cualquier tecla para cerrar el programa...");
                Console.ReadLine();

            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(error.Message);
            }
                       
            




        }

        }

        
    }

