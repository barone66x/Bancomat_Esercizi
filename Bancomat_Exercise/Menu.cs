﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat_Exercise
{
    public static class Menu
    {
        //public void CheckLogin()
        //{

        //}
        public static void WelcomeMenu(Bank bank)
        {
            int chance = 3;
            Console.WriteLine("Welcome to Bankomat with the K");
            Console.WriteLine("please insert username");
            string username = Console.ReadLine();

            while (!bank.bancomat1.CheckUsername(username))
            {
                Console.WriteLine("incorrect username");
                Console.WriteLine("please insert username");
                username = Console.ReadLine();
            }

            if (bank.CheckBan(username))
            {
                Console.WriteLine("you are currenty banned from the system");
                Console.ReadKey();
                return;
            }

            while (chance > 0)
            {
                Console.WriteLine("please insert password");
                string password = Console.ReadLine();
                Customer customer = bank.bancomat1.CheckCustomer(username, password);
                if (customer != null) //controllo esistenza oggetto con username e password corretti
                {
                    Console.WriteLine("login successfully");
                    CustomerMenu(customer, bank);
                }
                else
                {
                    chance -= 1;
                    Console.WriteLine($"incorrect password ,{chance} chance lefts!");
                }


            }

            if (chance <= 0)
            {
                Console.WriteLine("you are banned from the system!!!");
                bank.BanCustomer(username);
                Console.ReadKey();
                return;

            }
        }

        public static void CustomerMenu(Customer customer, Bank bank)
        {
            int esci = 1;
            while (esci != 0)
            {
                Console.WriteLine("please select the iban of the current count you want to use: ");
                string iban = bank.bancomat1.SearchCurrentAccounts(customer);
                esci = CurrentCountMenu(iban, bank);

            }

        }



        public static int CurrentCountMenu(string iban, Bank bank)
        {
            double amount = 0;
            Console.WriteLine("select 1 for Withdrawal, 2 for Payment, 3 for get your Balance,4 for return to Welcome Screen");
            int input = 0;
            try
            {
                input = int.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine("please insert a number!!!!");
                // CurrentCountMenu(iban, bank);
                return 0;

            }



            switch (input)
            {
                case 1:
                    amount = ValidateAmount();
                    if (amount == 0)
                    {
                        CurrentCountMenu(iban, bank);
                    }
                    bank.bancomat1.ApplicateOperation(iban, "Withdrawal", amount);
                    //  CurrentCountMenu(iban, bank);
                    return 0;
                //break;

                case 2:
                    amount = ValidateAmount();
                    if (amount == 0)
                    {
                        CurrentCountMenu(iban, bank);
                    }
                    bank.bancomat1.ApplicateOperation(iban, "Payment", amount);
                    CurrentCountMenu(iban, bank);
                    //  CurrentCountMenu(iban, bank);
                    return 0;
                //break;

                case 3:
                    bank.bancomat1.ApplicateOperation(iban, "Balance");
                    CurrentCountMenu(iban, bank);
                    //  CurrentCountMenu(iban, bank);
                    return 0;
                //break;

                case 4:
                    return 1;

                default:
                    Console.WriteLine("invalid number choice");
                    CurrentCountMenu(iban, bank);
                    //  CurrentCountMenu(iban, bank);
                    return 0;
                    //break;
            }




        }

        public static double ValidateAmount()
        {
            double amount = 0;


            Console.WriteLine("insert an amount");
            try
            {
                amount = double.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine("error, this isn't a valid amount");
            }
            return amount;
        }




    }
}

