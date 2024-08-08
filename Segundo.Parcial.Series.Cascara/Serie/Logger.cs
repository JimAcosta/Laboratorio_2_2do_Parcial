using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
            string logMessage = $"{DateTime.Now}: {message}";

            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    writer.WriteLine(logMessage);
                }
                Console.WriteLine("El mensaje de excepción ha sido registrado en el archivo de log.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el mensaje de excepción: {ex.Message}");
            }
        }
    }
}
