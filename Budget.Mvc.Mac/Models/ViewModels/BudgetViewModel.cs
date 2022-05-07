namespace Budget.Mvc.Mac.Models.ViewModels
{
    public class BudgetViewModel
    {
        public List<Transaction>? Transactions { get; set; }
        public InsertTransactionViewModel InsertTransaction { get; set; }
        public CategoriesViewModel Categories { get; set; }
    }
}

