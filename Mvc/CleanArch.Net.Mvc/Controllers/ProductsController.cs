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
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (ModelState.IsValid is false)
            return View(model);
        await useCase.AddAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var model = await useCase.GetByIdAsync(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel model)
    {
        if (ModelState.IsValid is false)
            return View(model);

        try
        {
            await useCase.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await useCase.GetByIdAsync(id);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var model = await useCase.GetByIdAsync(id);
        
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await useCase.RemoveAsync(id);
        
        return RedirectToAction(nameof(Index));
    }
}