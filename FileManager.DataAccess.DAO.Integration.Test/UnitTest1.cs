using System;
using FileManager.DataAccess.DAO.Aeroport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileManager.DataAccess.DAO.Integration.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingletonVueloIntegrationTest()
        {
            SingletonVuelo singletonVueloReal = SingletonVuelo.Instance;
            SingletonVuelo singletonVueloFake = SingletonVuelo.Instance;

            Assert.AreEqual(singletonVueloReal.SingletonGuid, singletonVueloFake.SingletonGuid);
            
        }
    }
}
