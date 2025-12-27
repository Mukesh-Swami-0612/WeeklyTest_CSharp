
using System;
using MediSureClinicBilling.Services;

namespace MediSureClinicBilling
{
    // Program class contains Main method
    // Main is ENTRY POINT of C# application
    class Program
    {
        static void Main()
        {
            int choice = 0;

            // Menu will repeat until user chooses Exit
            do
            {
                Console.WriteLine("\n=== MediSure Clinic Billing System ===");
                Console.WriteLine("1. Generate New Bill");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Delete Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                // Input validation
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                // Switch based on choice
                switch (choice)
                {
                    case 1:
                        BillingService.GenerateBill();
                        break;

                    case 2:
                        BillingService.ShowLastBill();
                        break;

                    case 3:
                        BillingService.DeleteLastBill();
                        break;

                    case 4:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 4);
        }
    }
}
