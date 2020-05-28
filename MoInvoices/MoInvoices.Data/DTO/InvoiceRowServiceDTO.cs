namespace MoInvoices.Transfer
{
    public class InvoiceRowServiceDTO
    {
        public int InvoiceRowServiceID { get; set; }
        public string ServiceName { get; set; }
        public string JM { get; set; }
        public int Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal NetWorth { get; set; }
        public string VatRate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossValue { get; set; }
    }
}