using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;

namespace Entidades
{
    public class Serializadora: IGuardar<List<Serie>>
    {
        public void Guardar(List<Serie> item, string ruta)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Serie>));
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    serializer.Serialize(writer, item);
                }
                Console.WriteLine($"El backlog de series ha sido guardado en formato XML en la ruta: {ruta}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new BackLogException("Error al guardar el backlog de series en formato XML.", ex);
            }
        }

        void IGuardar<List<Serie>>.Guardar(List<Serie> item, string ruta)
        {
            try
            {
                string json = JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(ruta, json);
                Console.WriteLine($"Las series para ver han sido guardadas en formato JSON en la ruta: {ruta}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new BackLogException("Error al guardar las series para ver en formato JSON.", ex);
            }
        }
    }
}
