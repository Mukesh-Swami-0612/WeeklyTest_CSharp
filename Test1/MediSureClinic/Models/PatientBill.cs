using System;

namespace MediSureClinicBilling.Models
{
    // This class is used to STORE data only
    // It represents ONE patient bill
    public class PatientBill
    {
        // Bill number (example: B101)
        public string BillNumber { get; set; }

        // Name of the patient
        public string PatientName { get; set; }

        // True = insurance available, False = no insurance
        public bool HasInsurance { get; set; }

        // Doctor consultation fee
        public decimal DoctorFee { get; set; }

        // Lab test charges
        public decimal LabFee { get; set; }

        // Medicine charges
        public decimal MedicineFee { get; set; }

        // Total amount before discount
        public decimal TotalAmount { get; set; }

        // Discount amount (insurance based)
        public decimal DiscountAmount { get; set; }

        // Final amount to be paid by patient
        public decimal NetPayable { get; set; }
    }
}
