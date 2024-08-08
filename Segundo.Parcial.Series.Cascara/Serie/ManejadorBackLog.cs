using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ManejadorBackLog
    {
        public event Action<Serie> SerieParaVer;

        public void IniciarManejador(List<Serie> series)
        {
            Task.Run(() => MoverSeries(series));
        }

        private void MoverSeries(List<Serie> series)
        {
            List<Serie> seriesCopy = new List<Serie>(series);

            foreach (var serie in seriesCopy)
            {
                try
                {
                    AccesoDatos.ActualizarSerie(serie);
                    Thread.Sleep(1500);

                    SerieParaVer?.Invoke(serie);
                }
                catch (Exception ex)
                {
                    string mensajeError = $"Error al mover la serie '{serie.Nombre}'";
                    Logger.Log($"{mensajeError}: {ex.Message}");
                    throw new BackLogException(mensajeError, ex);
                }
            }
        }
    }
}
