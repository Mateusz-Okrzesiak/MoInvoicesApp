using System.ComponentModel.DataAnnotations;

namespace MoInvoices.Data.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
