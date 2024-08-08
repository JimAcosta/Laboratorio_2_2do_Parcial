namespace Entidades
{
    public class Serie
    {
        private string genero;
        private string nombre;

        public Serie(string genero, string nombre)
        {
            this.genero = genero;
            this.nombre = nombre;
        }

        public Serie()
        {
            this.genero = "";
            this.nombre = "";
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Género: {genero}";
        }
    }
}
