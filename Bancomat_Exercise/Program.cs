using System;

namespace Bancomat_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Unicredit", Value.EUR);
            bank.Customers.Add(new("Pippo", "12345", "01"));
            bank.Customers.Add(new("Pluto", "ciaociao", "02"));
            bank.CreateBancomat();
            bank.CurrentAccounts.Add(new("IT00010120", "01"));
            bank.CurrentAccounts.Add(new("IT02320120", "01"));
            bank.CurrentAccounts.Add(new("IT19943900", "02"));

            Menu.WelcomeMenu(bank);

        }
    }
}
