using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensoraRandom
    {
        private static Random random = new Random();

        public static int GenerarRandom(this List<Serie> lista)
        {
            if(lista.Count<=0)
            {
                throw new ArgumentException("El tamaño de la coleccion debe ser mayor a 0");
            }

            return random.Next(0,lista.Count);
        }
    }
}
