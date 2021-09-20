using ChallengeRecursiva.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChallengeRecursiva.Helpers
{
    class Helper
    {
        
        internal static List<SociosModel> leerArchivo(string path)
        {
           
            var lines = File.ReadAllLines(path, Encoding.UTF7);
            
            List<SociosModel> socios = new List<SociosModel>();

            foreach (var line in lines)
            {
                var values = line.Split(';');

                SociosModel socio = new SociosModel() {
                 Nombre = values[0],
                 Edad = Int32.Parse(values[1]), 
                 Equipo = values[2],
                 EstadoCivil = values[3], 
                 NivelEstudios = values[4] };

                socios.Add(socio);
            }

            return socios;

        }


        internal static List<string> Consultas(string opcion, List<SociosModel> socios)
        {
            List<string> listastring = new List<string>();
            switch (opcion)
            {
                case "2":
                    double promedio = socios.Where(cas => cas.Equipo == "Racing")
                                             .Select(e => e.Edad)
                                             .Average();
                                             

                    listastring.Add(Math.Round(promedio).ToString());
                    return listastring;


                case "3":
                    return socios.Where(soc => soc.EstadoCivil == "Casado" && soc.NivelEstudios == "Universitario")
                                   .Take(100)
                                   .OrderBy(soc => soc.Edad)
                                   .Select(soc =>soc.Nombre + ",Edad: " + soc.Edad + ",Equipo: " + soc.Equipo)
                                   .ToList();

                case "4":
                    var query = socios.Where(soc => soc.Equipo == "River");
                    var result = from soc in query
                                 group soc by soc.Nombre into g
                                 orderby g.Count() descending
                                 select new
                                 {
                                     Nombre = g.Key,
                                     cantidad = g.Count()
                                 };

                    var lista = result.Take(5);
                    foreach (var item in lista)
                    {
                        listastring.Add(item.Nombre);
                    }
                    return listastring;


                case "5":
                    var equipos = from soc in socios
                              group soc by soc.Equipo into g
                              orderby g.Count() descending
                              select new
                              {
                                  Nombre = g.Key,
                                  cantidad = g.Count(),
                                  edad = g.Key
                              };

                    foreach (var item in equipos)
                    {
                        var edad = socios.Where(c => c.Equipo == item.Nombre)
                                            .Select(e => e.Edad);

                        listastring.Add(item.Nombre + ": " + "Edad Promedio de socios:" + " " +Math.Round(edad.Average()) + ",Edad Minima:" + edad.Min() + ",Edad Maxima:" + edad.Max());

                    }
                    return listastring;

                default:
                    return listastring;
            }
                               

        }
    }
}
