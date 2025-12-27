
using System;
using QuickMartTraders.Models;

namespace QuickMartTraders.Services
{
    // This class handles calculation logic
    public class TransactionService
    {
        // Method to calculate Profit / Loss / Break-Even
        public void CalculateResult(SaleTransaction sale)
        {
            // If selling price is greater than cost price → PROFIT
            if (sale.SellingPrice > sale.CostPrice)
            {
                sale.Result = "PROFIT";
                sale.ResultAmount = sale.SellingPrice - sale.CostPrice;
            }
            // If selling price is less than cost price → LOSS
            else if (sale.SellingPrice < sale.CostPrice)
            {
                sale.Result = "LOSS";
                sale.ResultAmount = sale.CostPrice - sale.SellingPrice;
            }
            // If both are equal → BREAK-EVEN
            else
            {
                sale.Result = "BREAK-EVEN";
                sale.ResultAmount = 0;
            }

            // Calculate profit or loss percentage
            sale.ResultPercent = (sale.ResultAmount / sale.CostPrice) * 100;
        }
    }
}
