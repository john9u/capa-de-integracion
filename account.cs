using System;
using System.Collections.Generic;

namespace WebApplication7
{
   
    public class hello
    {
        public int id { get; set; }
        public string info { get; set; }
        public decimal size { get; set; }
    }
    public class Account
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; private set; }

        //[Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; private set; }

        public int ClientId { get; set; }

        public virtual List<Loan> Loans { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
    public class Deposit : Transaction
    {

    }
    public class Loan
    {
        public int Id { get; set; }

        public float YearlyInterestRate { get; set; }
        public int DurationInMonths { get; set; }

        // [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        public int AccountId { get; set; }
        public string Information { get; set; }
        public double MonthlyPayment { get; set; }

        // [Column(TypeName = "decimal(10,2)")]
        public decimal RemainingAmount { get; set; }
    }
    public abstract class Transaction
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Amount { get; set; }

        public string Information { get; set; }

        public int AccountId { get; set; }

        public string Discriminator { get; set; }
    }

    public class Withdrawal : Transaction
    {

    }




}
