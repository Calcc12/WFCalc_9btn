using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace apiTest_9_btn
{
    [TestClass]
    public class UnitTest1
    {
        calc calic = new calc();
        [DataTestMethod]
        [DataRow(5, 6, '+', 11)]
        [DataRow(10, 6, '-', 4)]
        [DataRow(2, 6, '*', 12)]
        [DataRow(10, 5, '/', 2)]
        public void CalcWF(int fNum, int sNun, char op, int Excpected)
        {
            Assert.AreEqual(Excpected, calic.Calc(fNum, sNun, op));
        }
    }
}
