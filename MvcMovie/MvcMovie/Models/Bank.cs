using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Bank
    {
        public static int AllMoney { get; set; }

        public static double DepositProcents { get; private set; }

        public static double CreditProcents { get; private set; }

        //public static ClientsDbContext DataBase { get; set; }

        public static List<Offer> Offers { get; set; } 

        public static BankLottery Lottery { get; set; }

        public static RubToDollarConvertor Convertor { get; set; }

        public static void Initialize()
        {
            AllMoney = int.MaxValue;
            DepositProcents = 0.25;
            CreditProcents = 0.05;
            //DataBase = new ClientsDbContext();
            Offers = new List<Offer>();
            Lottery = new BankLottery(100, 100);
            Convertor = new RubToDollarConvertor();
        }

    }

    public class RubToDollarConvertor
    {
        public static double RubToDollarCoefficient { get; private set; }

        public static double SetCoefficient(double coeff)
        {
            RubToDollarCoefficient = coeff;

            return RubToDollarCoefficient;
        }

        public static double ConvertToDollars(int rubs)
        {
            return rubs*RubToDollarCoefficient;
        }

        public static int ConvertToRubs(double dollars)
        {
            return (int) (dollars/RubToDollarCoefficient);
        }
    }

    public class BankLottery
    {
        public int NTickets;

        public int NTicketCells;

        public List<Ticket> Tickets; 

        public BankLottery(int nTickets, int nTicketCells)
        {
            NTickets = nTickets;
            NTicketCells = nTicketCells;
            Tickets = new List<Ticket>();
        }

        public List<Ticket> CreateTickets()
        {
            for (int i = 0; i < NTickets; i++)
            {
                Tickets.Add(new Ticket(i + 1, NTicketCells));
            }

            return Tickets;
        }
    }

    public class Ticket
    {
        public int ID;

        public int NCells;
        
        public List<int> Cells;

        public BankLottery Lottery { get; set; }

        public Ticket(int id, int nCells)
        {
            ID = id;
            NCells = nCells;
            Cells = new List<int>();
            for (int i = 0; i < NCells; i++)
            {
                Cells.Add(i + 1);
            }
        }

        public List<int> ChooseCells()
        {
            Random random = new Random();
       
            for (int i = 0; i < 10; i++)
            {
                int num = random.Next(1, NCells);

                Cells[num] = 0;
            }

            return Cells;
        }

        public List<int> ChooseCells(int[] cells)
        {
            for (int i = 0; i < 10; i++)
            {
                Cells[cells[i] - 1] = 0;
            }

            return Cells;
        }
    }

    public class Offer
    {
        
    }
}