﻿using System;


namespace Banking_App
{
    class BankingApp
    {


        public class Account
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

            private string m_name;
            private string m_address;
            private decimal m_balance = 25; //  ***** temporary value for debugging
            private AccountState m_state;
            private AccountType m_accountType;
        

        public bool WithdrawFunds(decimal withdraw)
            {
                if (withdraw > m_balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return false;
                }
                else
                {
                    m_balance = m_balance - withdraw;
                    Console.WriteLine(withdraw + " withdrawn");
                    return true;
                }
            }
        }



        // Input Handling

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

        public static int EnterDecimal(decimal min, decimal max)
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
        // Now define account structure




        public static void MainMenu()
        {

            Console.WriteLine("Banking menu\n");
            Console.WriteLine("1 = Withdraw funds\n2 = create account\n");

            int option = EnterInteger(1, 2);

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



        public static void Main()
        {
            MainMenu();

            AccountStruct AndyAccount;
            AndyAccount.State = AccountState.Active;
            AndyAccount.Balance = 1000;

            Account Andy;
            Andy = new Account();

            Console.Write("Enter name: ");

            string nameinput = Console.ReadLine();
            Andy.m_name = nameinput;
            Console.Write("Name = ");
            Console.WriteLine(Andy.m_name);


            Console.WriteLine("How much do you wish to withdraw?");
            decimal withdrawrequest;
            string withdrawstring;
            withdrawstring = Console.ReadLine();
            withdrawrequest = decimal.Parse(withdrawstring);

            if (Andy.WithdrawFunds(withdrawrequest) == true)
                Console.WriteLine("Withdrawal successful");
            else

                Console.Write("Withdrawal failed.");


            Console.ReadLine();
        }

    }




}




