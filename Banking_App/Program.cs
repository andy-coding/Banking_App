using System;


namespace Banking_App
{
    interface IAccount
    {
        string Name
            {get; set;}
        bool WithdrawFunds(decimal withdraw);
        decimal GetBalance();
        bool DepositFunds(decimal deposit);
        string ToString();
        bool Equals(object o);
    }
     

    class Account : IAccount
    {
        enum AccountState
        {
                New,
                Active,
                UnderAudit,
                Frozen,
                Closed
        };

        enum AccountType
        {
            Current,
            StandardInterest,
            HighInterest,
        };

        private string name;
        public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }

        private string address;
        private decimal balance = 25; //  ***** temporary value for debugging
        private AccountState state;
        private AccountType accountType;
           
        public virtual bool WithdrawFunds(decimal withdrawAmount)
        {
           // Console.WriteLine("name: {0}    Name:  {1}", name, Name);

            if (withdrawAmount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
            else
            {
                balance = balance - withdrawAmount;
                Console.WriteLine("£" + withdrawAmount + " withdrawn from account: " + this.Name + ". Balance is now: £" + balance);
                return true;
            }
        }

 
        public decimal GetBalance()
        {
            return balance;
        }

        public bool DepositFunds(decimal deposit)
        {
            return true;
        }  

        public override string ToString()
        {
            return "AccountState: " + this.state + "/nAccountTyoe: " + this.accountType + "/nm_name: " + this.name + "/nm_address: " + this.address + "/nm_balance: " + this.balance; 
        }

        public override bool Equals(object obj)
        {
            Account p = (Account)obj;

            if ((p.name == "Bob") && (p.address == this.address) && (p.balance == this.balance) && (p.state == this.state) && (p.accountType == this.accountType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

    
    class CustomerAccount : Account
    {

    }

    class BabyAccount : Account
    {
        public override bool WithdrawFunds(decimal withdrawAmount)
        {
            if (withdrawAmount > 10)
            {
                Console.WriteLine("You cannot withdraw more than £10 from Account " + this.Name);
                return false;
            }
            else
            {
                return base.WithdrawFunds(withdrawAmount);
            }
        }
    }

    class InputHandling     //Input Handling
    {
        public static int EnterInteger(int min, int max)
        {

            int input = 0;

            do
            {
                try
                {
                    string inputString = Console.ReadLine();
                    input = int.Parse(inputString);
                }
                catch
                {
                    Console.WriteLine("Please enter again");
                }
            }
            while (input < min || input > max);

            return input;
        }

        public static decimal EnterDecimal(decimal min, decimal max)
        {

            decimal input = 0;

            do
            {
                try
                {
                    string inputString = Console.ReadLine();
                    input = decimal.Parse(inputString);
                }
                catch
                {
                    Console.WriteLine("Please enter again");
                }
            }
            while (input < min || input > max);

            return input;
        }

    }

    class Menu
    {
            public static void MainMenu() //This displays the mein menu
            {

                Console.WriteLine("Banking menu\n");
                Console.WriteLine("1 = Withdraw funds\n2 = create account\n");

                int option = InputHandling.EnterInteger(1, 2);

                do
                {
                    switch (option)
                    {
                        case 1:
                            // WithdrawFunds();
                            break;
                        case 2:
                            //      Quit();
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
             while (option < 1 || option > 2);

            }
    }           

    class BankingApp
    {

        public static void Main()
        {
            //Menu.MainMenu();

            //AccountStruct AndyAccount;
            //AndyAccount.State = AccountState.Active;
            //AndyAccount.Balance = 1000;


            // Test to create account  
            Account Andy;
            Andy = new CustomerAccount();

            Console.Write("Enter name of customer account: ");

            string nameinput = Console.ReadLine();
            Andy.Name = nameinput;
            Console.WriteLine("Name = " + Andy.Name);
            
            Account BabyAndy;
            BabyAndy = new BabyAccount();

            Console.Write("Enter name of baby account: ");

            nameinput = Console.ReadLine();
            BabyAndy.Name = nameinput;
            Console.WriteLine("Name = " + Andy.Name);

             //   Test withdraw of funds
            Console.WriteLine("How much do you wish to withdraw?");
            decimal withdrawrequest;
            string withdrawstring;
            withdrawstring = Console.ReadLine();
            withdrawrequest = decimal.Parse(withdrawstring);

            Andy.WithdrawFunds(withdrawrequest);
            BabyAndy.WithdrawFunds(withdrawrequest);

            Console.ReadLine();
            

        }

    }




}




