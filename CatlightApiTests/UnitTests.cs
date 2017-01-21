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
            var doesNeedAttention = catlight.DoesNeedAttention();
        }
        }
    }
}