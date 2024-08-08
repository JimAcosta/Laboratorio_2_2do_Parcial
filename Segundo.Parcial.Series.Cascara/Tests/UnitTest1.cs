namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearBackLogException_SoloMensaje_DeberiaTenerMensaje()
        {
            string mensaje = "Error de backlog";

            var exception = new BackLogException(mensaje);

            Assert.AreEqual(mensaje, exception.Message);
        }

        [TestMethod]

        public void CrearBackLogException_MensajeYInnerException_DeberiaTenerMensajeYInnerException()
        {
            string mensaje = "Error de backlog";
            var innerException = new Exception("Inner exception");

            var exception = new BackLogException(mensaje, innerException);

            Assert.AreEqual(mensaje, exception.Message);
            Assert.AreEqual(innerException, exception.InnerException);
        }

        
    }
}