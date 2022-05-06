using System.Diagnostics;
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

        var viewModel = new BudgetViewModel
        {
            Transactions = transactions
        };

        return View(viewModel);
    }
}

