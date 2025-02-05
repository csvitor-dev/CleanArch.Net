using CleanArch.Net.Application.UseCases.Product.Contracts;
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
}