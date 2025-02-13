using CleanArch.Net.Application.UseCases.Product.Contracts;
using CleanArch.Net.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Net.Mvc.Controllers;

public class ProductsController(IProductUseCase useCase) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await useCase.GetAllAsync();

        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
        => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Name,Description,Price")] ProductViewModel model
    )
    {
        if (ModelState.IsValid is false)
            return View(model);
        await useCase.AddAsync(model);

        return RedirectToAction(nameof(Index));
    }
}