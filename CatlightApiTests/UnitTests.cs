using System;
using CatlightApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatlightApiTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CallStatus_ThrowsNoException()
        {
            var catlight = new Catlight();
            try
            {
                catlight.DoesNeedAttention();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}