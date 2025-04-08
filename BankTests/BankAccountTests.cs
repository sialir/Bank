using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 11.991;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance); // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 11.991;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance); // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
           account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance); // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message,
               BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Подготовка
            double beginningBalance = 11.99;
            double creditAmount = 5.55;
            double expected = 17.54;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Действие
            account.Credit(creditAmount);

            // Проверка
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Баланс не обновлен корректно");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Подготовка
            double beginningBalance = 11.99;
            double creditAmount = -100.0;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Действие
            account.Credit(creditAmount);

            // Проверка
            // Исключение ожидается, дополнительные проверки не требуются.
        }
    }
}