using System;
using System.Windows.Forms;
using GPL_Application_2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void ChkTriangleValidity()
        {
            Triangle T = new Triangle();
            T.GetValue(1, 2, 0, 3);
            bool exceptedResult =false;
            bool actualResult =T.checkTriangleValidity();
            Assert.AreEqual(exceptedResult, actualResult);
        }

        [TestMethod]
        public void ChkTriangleValidity1()
        {
            Triangle T = new Triangle();
            T.GetValue(50, 50, 50, 50);
            bool exceptedResult = true;
            bool actualResult = T.checkTriangleValidity();
            Assert.AreEqual(exceptedResult, actualResult);
        }

        [TestMethod]
        public void Validation()
        {
            TextBox TB = new TextBox();
            TB.Text = "Circle 50";
            CommandValidations V = new CommandValidations(TB);
            bool exceptedResult = true;
            bool actualResult = V.IsCmdValid;
            Assert.AreEqual(exceptedResult, actualResult);
        }

        [TestMethod]
        public void Validation1()
        {
            TextBox TB = new TextBox();
            TB.Text = "Circle 50,50";
            CommandValidations V = new CommandValidations(TB);
            bool exceptedResult = false;
            bool actualResult = V.IsCmdValid;
            Assert.AreEqual(exceptedResult, actualResult);
        }

        [TestMethod]
        public void CheckCmdLineValidation()
        {
            TextBox TB = new TextBox();
            TB.Text = "moveto 60,40";
            CommandValidations V = new CommandValidations(TB);
            bool expectedResult = true;
            bool actualResult;
            V.CheckCmdLineValidation(TB.Text);
            actualResult = V.IsSyntaxValid;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void checkLoopAndIfValidation()
        {
            String input;
            Boolean expectedOutcome;
            Boolean realOutcome;
            TextBox textbox = new TextBox();
            input = "counter = 5 \r\n If counter = 5 then \r\n radius = 100 \r\n Circle radius \r\n EndIf";
            textbox.Text = input;
            expectedOutcome = true;

            CommandValidations validation = new CommandValidations(textbox);
            validation.CheckCmdLoopAndIfValidation();

            realOutcome = validation.IsCmdValid;
            Assert.AreEqual(expectedOutcome, realOutcome);
        }
        [TestMethod]
        public void checkIfVariableDefinedTest()
        {
            String input;
            Boolean expectedOutcome;
            Boolean realOutcome;
            TextBox textbox = new TextBox();
            input = "Radius = 20 \r\n Circle Radius";
            expectedOutcome = true;

            textbox.Text = input;
            CommandValidations validation = new CommandValidations(textbox);
            validation.checkIfVariableDefined("radius");

            realOutcome = validation.IsCmdValid;
            Assert.AreEqual(expectedOutcome, realOutcome);
        }
    }
}
    


    
