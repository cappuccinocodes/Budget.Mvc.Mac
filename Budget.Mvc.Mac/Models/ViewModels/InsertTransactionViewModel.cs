using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budget.Mvc.Mac.Models.ViewModels
{
	public class InsertTransactionViewModel
	{
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Type")]
        public TransactionType TransactionType { get; set; }

        public List<Category>? Categories { get; set; }
    }
}

