using Budget.Mvc.Mac.Models;
using Budget.Mvc.Mac.Models.ViewModels;
using Budget.Mvc.Mac.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Mvc.Mac.Controllers;

public class HomeController : Controller
{
    private readonly IBudgetRepository _budgetRepository;

    public HomeController(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public IActionResult Index()
    {
        var transactions = _budgetRepository.GetTransactions();
        var categories = _budgetRepository.GetCategories();

        var viewModel = new BudgetViewModel
        {
            Transactions = transactions,
            InsertTransaction = new InsertTransactionViewModel { Categories = categories },
            Categories = new CategoriesViewModel { Categories = categories },
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult InsertTransaction(BudgetViewModel model)
    {
        var transaction = new Transaction
        {
            Id = model.InsertTransaction.Id,
            Amount = model.InsertTransaction.Amount,
            Name = model.InsertTransaction.Name,
            Date = model.InsertTransaction.Date,
            TransactionType = model.InsertTransaction.TransactionType,
            CategoryId = model.InsertTransaction.CategoryId
        };

        if (transaction.Id > 0)
            _budgetRepository.UpdateTransaction(transaction);
        else
            _budgetRepository.AddTransaction(transaction);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteTransaction(int id)
    {
        _budgetRepository.DeleteTransaction(id);

        return RedirectToAction("Index");
    }
}

