using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TradeApp.Core.Functions;

namespace TradeApp.Core.Function.Tests
{
    [TestClass()]
    public class VerificateTests
    {
        [TestMethod()]
        public void VerificateTest_false()
        {
            var verif = new Verificate();

            //Allert
            string password = "111111";
            string login = "21312";
            string expected = "Неверный логин или пароль";

            //Act
            var result = verif.Check(login, password);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void VerificateTest_true()
        {
            var verif = new Verificate();

            //Allert
            string password = "2L6KZG";
            string login = "pixil59@gmail.com";
            string expected = "Вход выполнен!";

            //Act
            var result = verif.Check(login, password);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}