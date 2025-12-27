using System;
using MediSureClinicBilling.Models;

namespace MediSureClinicBilling.Services
{
    // This class contains BUSINESS LOGIC
    // Means calculation and operations
    public static class BillingService
    {
        // This variable stores the last generated bill
        private static PatientBill lastBill = null;

        // This method creates a new bill
        public static void GenerateBill()
        {
            // Create object of PatientBill class
            PatientBill bill = new PatientBill();

            // Taking bill number input
            Console.Write("Enter Bill Number: ");
            bill.BillNumber = Console.ReadLine();

            // Taking patient name input
            Console.Write("Enter Patient Name: ");
            bill.PatientName = Console.ReadLine();

            // Check empty values
            if (string.IsNullOrWhiteSpace(bill.BillNumber) ||
                string.IsNullOrWhiteSpace(bill.PatientName))
            {
                Console.WriteLine("Bill Number and Patient Name are required.");
                return;
            }

            // Insurance input (Y/N)
            Console.Write("Insurance Available (Y/N): ");
            string insuranceInput = Console.ReadLine().ToUpper();
            bill.HasInsurance = insuranceInput == "Y";

            // Read all charges
            bill.DoctorFee = ReadAmount("Doctor Fee");
            bill.LabFee = ReadAmount("Lab Fee");
            bill.MedicineFee = ReadAmount("Medicine Fee");

            // Calculate total, discount and payable
            CalculateBill(bill);

            // Store bill as last bill
            lastBill = bill;

            Console.WriteLine("\n✔ Bill Generated Successfully");
        }

        // This method reads amount safely
        private static decimal ReadAmount(string message)
        {
            Console.Write($"Enter {message}: ");

            // TryParse avoids program crash
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount entered.");
                Environment.Exit(0);
            }

            return amount;
        }

        // This method does all calculations
        private static void CalculateBill(PatientBill bill)
        {
            // Total = sum of all fees
            bill.TotalAmount = bill.DoctorFee + bill.LabFee + bill.MedicineFee;

            // If insurance available → 10% discount
            if (bill.HasInsurance)
            {
                bill.DiscountAmount = bill.TotalAmount * 0.10m;
            }
            else
            {
                bill.DiscountAmount = 0;
            }

            // Final payable amount
            bill.NetPayable = bill.TotalAmount - bill.DiscountAmount;
        }

        // Show last bill details
        public static void ShowLastBill()
        {
            // If no bill exists
            if (lastBill == null)
            {
                Console.WriteLine("No bill found.");
                return;
            }

            Console.WriteLine("\n------ Last Bill Details ------");
            Console.WriteLine($"Bill No      : {lastBill.BillNumber}");
            Console.WriteLine($"Patient Name : {lastBill.PatientName}");
            Console.WriteLine($"Insurance    : {(lastBill.HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Doctor Fee   : {lastBill.DoctorFee}");
            Console.WriteLine($"Lab Fee      : {lastBill.LabFee}");
            Console.WriteLine($"Medicine Fee : {lastBill.MedicineFee}");
            Console.WriteLine($"Total        : {lastBill.TotalAmount}");
            Console.WriteLine($"Discount     : {lastBill.DiscountAmount}");
            Console.WriteLine($"Payable      : {lastBill.NetPayable}");
            Console.WriteLine("----------------------
