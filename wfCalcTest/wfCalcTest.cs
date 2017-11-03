using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using WindowsFormsApp1;

namespace wfCalcTest
{
    [TestClass]
    public class WF
    {
        calc calcc = new calc();
        private static Window window;
        [ClassInitialize]
        public static void Class_Init(TestContext context)
        {
            Application application = Application.Launch(@"D:\calc.exe");
            window = application.GetWindow("Calc", InitializeOption.NoCache);
        }
        [TestCleanup]
        public void Data_Clean()
        {
            window.Close();
            Application application =Application.Launch(@"D:\calc.exe");
            window = application.GetWindow("Calc", InitializeOption.NoCache);
        }
        [ClassCleanup]
        public static void Class_Clean()
        {
            window.Close();
        }
        [DataTestMethod]
        [DataRow("btn1")]
        [DataRow("btn2")]
        [DataRow("btn3")]
        [DataRow("btn4")]
        [DataRow("btn5")]
        [DataRow("btn6")]
        [DataRow("btn7")]
        [DataRow("btn8")]
        [DataRow("btn9")]
        [DataRow("btn0")]
        [DataRow("add")]
        [DataRow("riz")]
        [DataRow("mult")]
        [DataRow("btnC")]
        [DataRow("Clear")]
        [DataRow("res")]
        [TestMethod]
        public void UI_PresenceButtons(string id)
        {
            Button butt = window.Get<Button>(id);
            bool btn = butt.Visible;
            Assert.AreEqual(true, btn);
        }
        [TestMethod]
        public void  UI_PresenceButtons()
        {
            TextBox x = window.Get<TextBox>("str");
            bool btn = x.Visible;
            Assert.AreEqual(true, btn);
        }
        [DataTestMethod]
        [DataRow("btn0", "0")]
        [DataRow("btn1", "1")]
        [DataRow("btn2", "2")]
        [DataRow("btn3", "3")]
        [DataRow("btn4", "4")]
        [DataRow("btn5", "5")]
        [DataRow("btn6", "6")]
        [DataRow("btn7", "7")]
        [DataRow("btn8", "8")]
        [DataRow("btn9", "9")]
        public void UI_SimplCheeck(string id, string expected)
        {
            window.Get<Button>(id).Click();
            string res = window.Get<TextBox>("str").Text;
            Assert.AreEqual(expected, res);
        }
        [DataTestMethod]
        [DataRow("btn0", "000")]
        [DataRow("btn1", "111")]
        [DataRow("btn2", "222")]
        [DataRow("btn3", "333")]
        [DataRow("btn4", "444")]
        [DataRow("btn5", "555")]
        [DataRow("btn6", "666")]
        [DataRow("btn7", "777")]
        [DataRow("btn8", "888")]
        [DataRow("btn9", "999")]
        public void UI_ComplexCheck(string id, string expected)
        {
            for (int i = 1; i <= 3; ++i)         
                window.Get<Button>(id).Click();
            TextBox actual = window.Get<TextBox>("str");
         //  Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("btn1", "btn2", "add", "3")]
        [DataRow("btn3", "btn4", "riz", "-1")]
        [DataRow("btn5", "btn6", "mult", "30")]
        [DataRow("btn9", "btn3", "div", "3")]
        [DataRow("btn9", "btn0", "add", "9")]
        public void UI_RealJobB(string firstNum, string secNum, string op, string res)
        {
            window.Get<Button>(firstNum).Click();
            window.Get<Button>(op).Click();
            window.Get<Button>(secNum).Click();
            window.Get<Button>("res").Click();
            string calc = window.Get<TextBox>("str").BulkText;
            Assert.AreEqual(res, calc);
        }
    }
}
