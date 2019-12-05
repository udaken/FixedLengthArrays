using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using FixedLengthArray;
namespace FixedLengthArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new FixedLengthByteArray3();
            Assert.IsTrue(a.Equals(in FixedLengthByteArray3.RefToZero));
            var b = new FixedLengthByteArray3();
            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            a.Fill(0x55);
            Assert.IsFalse(a.Equals(b));
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
            b.Fill(0x55);
            Assert.AreEqual(a, b);

            var h = a.GetHashCode();

            ;
        }
    }
}
