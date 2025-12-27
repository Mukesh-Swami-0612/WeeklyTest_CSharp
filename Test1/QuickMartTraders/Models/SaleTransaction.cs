
using System;

namespace QuickMartTraders.Models
{
    // This class is used to STORE sale details
    // It does NOT contain logic
    public class SaleTransaction
    {
        // Invoice number of the sale
        public string InvoiceNo { get; set; }

        // Name of the customer
        public string CustomerName { get; set; }

        // Name of the item sold
        public string ItemName { get; set; }

        // Quantity of items sold
        public int Quantity { get; set; }

        // Total purchase amount (cost price)
        public decimal CostPrice { get; set; }

        // Total selling amount
        public decimal SellingPrice { get; set; }

        // Result of transaction → PROFIT / LOSS / BREAK-EVEN
        public string Result { get; set; }

        // Profit or Loss amount
        public decimal ResultAmount { get; set; }

        // Profit or Loss percentage
        public decimal ResultPercent { get; set; }
    }
}
