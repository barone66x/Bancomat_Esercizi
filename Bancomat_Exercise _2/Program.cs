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

            bank.CurrentAccounts.Add(new("IT00010120", "01"));
            bank.CurrentAccounts.Add(new("IT02320120", "01"));
            bank.CurrentAccounts.Add(new("IT19943900", "02"));

            bank.CurrentAccounts[1].CreateBancomat("123454", "6666");
            bank.CurrentAccounts[2].CreateBancomat("444444", "7777");
            bank.CurrentAccounts[3].CreateBancomat("432122", "9999");

            while (true) { Menu.WelcomeMenu(bank); }


        }
    }
}
