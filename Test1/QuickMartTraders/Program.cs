
using System;
using QuickMartTraders.Models;
using QuickMartTraders.Services;

namespace QuickMartTraders
{
    class Program
    {
        // Variable to store last transaction
        static SaleTransaction lastSale = null;

        // Create object of service class
        static TransactionService service = new TransactionService();

        // Program execution starts from Main()
        static void Main(string[] args)
        {
            int choice;

            // Menu runs again and again until user exits
            do
            {
                Console.WriteLine("\nQuickMart Profit Calculator");
                Console.WriteLine("1. Enter New Sale");
                Console.WriteLine("2. Show Last Sale");
                Console.WriteLine("3. Calculate Profit / Loss Again");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                // Validate user input
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Enter number only.");
                    continue;
                }

                // Menu selection
                switch (choice)
                {
                    case 1:
                        AddNewSale();
                        break;

                    case 2:
                        ShowSale();
                        break;

                    case 3:
                        ReCalculate();
                        break;

                    case 4:
                        Console.WriteLine("Program Closed.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (choice != 4);
        }

        // Method to enter new sale details
        static void AddNewSale()
        {
            // Create object of SaleTransaction
            SaleTransaction sale = new SaleTransaction();

            Console.Write("Invoice No: ");
            sale.InvoiceNo = Console.ReadLine();

            Console.Write("Customer Name: ");
            sale.CustomerName = Console.ReadLine();

            Console.Write("Item Name: ");
            sale.ItemName = Console.ReadLine();

            Console.Write("Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }
            sale.Quantity = qty;

            Console.Write("Purchase Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal cost) || cost <= 0)
            {
                Console.WriteLine("Invalid purchase amount.");
                return;
            }
            sale.CostPrice = cost;

            Console.Write("Selling Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal sell) || sell < 0)
            {
                Console.WriteLine("Invalid selling amount.");
                return;
            }
            sale.SellingPrice = sell;

            // Call service method to calculate result
            service.CalculateResult(sale);

            // Save last transaction
            lastSale = sale;

            Console.WriteLine("\nSale saved successfully!");
            Console.WriteLine("Result: " + sale.Result);
            Console.WriteLine("Amount: " + sale.ResultAmount);
            Console.WriteLine("Percentage: " + sale.ResultPercent);
        }

        // Method to show last sale
        static void ShowSale()
        {
            // If no sale exists
            if (lastSale == null)
            {
                Console.WriteLine("No sale found.");
                return;
            }

            Console.WriteLine("\n------ Last Sale Details ------");
            Console.WriteLine("Invoice No   : " + lastSale.InvoiceNo);
            Console.WriteLine("Customer     : " + lastSale.CustomerName);
            Console.WriteLine("Item         : " + lastSale.ItemName);
            Console.WriteLine("Quantity     : " + lastSale.Quantity);
            Console.WriteLine("Cost Price   : " + lastSale.CostPrice);
            Console.WriteLine("Selling Price: " + lastSale.SellingPrice);
            Console.WriteLine("Result       : " + lastSale.Result);
            Console.WriteLine("Amount       : " + lastSale.ResultAmount);
            Console.WriteLine("Percentage   : " + lastSale.ResultPercent);
            Console.WriteLine("--------------------------------");
        }

        // Method to re-calculate profit/loss
        static void ReCalculate()
        {
            if (lastSale == null)
            {
                Console.WriteLine("No sale found to calculate.");
                return;
            }

            // Recalculate using service
            service.CalculateResult(lastSale);

            Console.WriteLine("\nCalculation Updated!");
            Console.WriteLine("Result: " + lastSale.Result);
            Console.WriteLine("Amount: " + lastSale.ResultAmount);
            Console.WriteLine("Percentage: " + lastSale.ResultPercent);
        }
    }
}
