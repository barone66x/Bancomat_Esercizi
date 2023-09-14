using System;
using System.Collections.Generic;
using System.Linq;

namespace Bancomat_Exercise
{
    public class Bank
    {
        public string BankName { get; }
        public Value ValueType { get; }
        public List<Customer> Customers { get; set; }
        public List<CurrentAccount> CurrentAccounts { get; set; }
        public Bancomat bancomat1 { get; set; }
        public Bank(string nome, Value valueType)
        {
            BankName = nome;
            ValueType = valueType;
            Customers = new List<Customer>();
            CurrentAccounts = new List<CurrentAccount>();

        }

        #region CURRENT ACCOUNT
        public class CurrentAccount
        {
            public string Iban { get; }
            public string IdOwner { get; }
            public double Balance { get; set; }




            public CurrentAccount(Customer owner) //Definitivo
            {
                Random random = new Random();
                //Iban = random.Next(1000, 100000); //iban di prova
                IdOwner = owner.IdCustomer;
                Balance = 1000;

            }

            public CurrentAccount(string iban, string idOwner) //per esercizio
            {
                Iban = iban;
                IdOwner = idOwner;
                Balance = 1000;
            }


            public void Withdrawal(double amount)
            {
                if (amount > 0)
                {
                    if (Balance > amount)
                    {
                        Balance -= amount;
                        Console.WriteLine("withdrawal successful"); //forse togliere per controllo esterno
                        //return 1; //Esito positivo

                    }
                    else
                    {
                        Console.WriteLine("insufficient balance"); //forse togliere per controllo esterno
                        //return 0; //Esito negativo
                    }

                }
                else
                {
                    Console.WriteLine("the amount to be withdrawn is 0 or less"); //forse togliere per controllo esterno
                                                                                  //   return 0; //esito negativo
                }


            }

            public void GetBalance() //forse non void
            {
                Console.WriteLine($"{DateTime.Now}  Balance: {Balance} "); //aggiungere value type

            }

            public void Payment(double amount) //forse non void
            {
                Balance += amount;
                Console.WriteLine("Payment successful"); //forse togliere per controllo esterno

            }

        }
        #endregion



        #region BANCOMAT
        public class Bancomat
        {
            public List<Customer> customers;
            public List<CurrentAccount> currentAccounts;
            public Bancomat(List<Customer> input, List<CurrentAccount> input2)
            {

                customers = input;
                currentAccounts = input2;

            }


            public bool CheckUsername(string username)
            {
                string result =
                    (from c in customers
                     where c.Username == username
                     select c.Username).FirstOrDefault();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

            public Customer CheckCustomer(string username, string password)
            {
                Customer customer = //Fare direttamente return per controllare
                    (from c in customers
                     where c.Username == username && c.Password == password
                     select c).FirstOrDefault();


                return customer;


            }

            public CurrentAccount SearchCurrentAccount(string iban)
            {
                CurrentAccount currentAccount =
                    (from c in currentAccounts
                     where c.Iban == iban
                     select c).FirstOrDefault();
                return currentAccount;
            }




            public string SearchCurrentAccounts(Customer customer)
            {
                List<CurrentAccount> currents = (
                    from c in currentAccounts
                    where c.IdOwner == customer.IdCustomer
                    select c).ToList();
                int i = 0;
                string iban = "";

                foreach (var conto in currents)
                {
                    Console.WriteLine($"number of choice: {i} iban: {conto.Iban}");
                    i += 1;
                }


                int input = 0;
                try
                {
                    input = int.Parse(Console.ReadLine());


                }
                catch (Exception ex)
                {
                    Console.WriteLine("please insert a number!!!!");
                    //Menu.CustomerMenu(customer);
                    SearchCurrentAccounts(customer);

                }

                try
                {
                    iban = currents[input].Iban;
                }
                catch (Exception e)
                {
                    Console.WriteLine("please select a valid number");
                    //Menu.CustomerMenu(customer, this);
                    SearchCurrentAccounts(customer);
                }

                return iban;
                //ContoCorrente contoSelezionato = (
                //    from c in conti
                //    where iban == c.Iban
                //    select c).FirstOrDefault();

            }
            public void ApplicateOperation(string iban, string operation, double amount = 0)
            {

                CurrentAccount account = SearchCurrentAccount(iban);
                switch (operation)
                {
                    case "Withdrawal":
                        account.Withdrawal(amount);
                        break;

                    case "Payment":
                        account.Payment(amount);
                        break;

                    case "Balance":
                        account.GetBalance();
                        break;
                    default:
                        Console.WriteLine("unexpted error");
                        break;
                }

            }
        }
        #endregion BANCOMAT





        //per programma definitivo
        //List<Customer> customers = new List<Customer>()
        //List<CurrentAccount> currentAccounts = new List<CurrentAccount>();

        #region CHEKCS


        #endregion




        public void CreateBancomat()
        {
            bancomat1 = new Bancomat(Customers, CurrentAccounts);
        }

        public void BanCustomer(string username)
        {
            Customer customer =
                (from c in Customers
                 where c.Username == username
                 select c).FirstOrDefault();
            customer.Ban = true;
        }

        public void UnBanCustomer(string username)
        {
            Customer customer =
                (from c in Customers
                 where c.Username == username
                 select c).FirstOrDefault();
            customer.Ban = false;
        }

        public bool CheckBan(string username)
        {
            Customer customer =
                (from c in Customers
                 where c.Username == username
                 select c).FirstOrDefault();
            if (customer.Ban)
            {
                return true;
            }
            else
            {
                return false;
            }


        }




        #region DA IMPLEMENTARE
        public void AddOwner(string username, string password)
        {

            // customers.Add(new(username, password));
        }

        public void AddCurrentAccount(Customer owner)
        {

            //currentAccounts.Add(new(owner));
        }
        #endregion



    }
}
