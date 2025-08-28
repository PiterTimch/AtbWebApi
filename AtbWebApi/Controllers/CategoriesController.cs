using Microsoft.AspNetCore.Mvc;

namespace AtbWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    [HttpGet()]
    public IActionResult GetCategories()
    {
        var category = new[]
            {
                new { Id = 1, Name = "Напої безалкогольні", Image = "https://src.zakaz.atbmarket.com/cache/category/Безалкогольні напої.webp" },
                new { Id = 2, Name = "Овочі та фрукти", Image = "https://src.zakaz.atbmarket.com/cache/category/Овочі та фрукти.webp" },
                new { Id = 3, Name = "Морозиво", Image = "https://src.zakaz.atbmarket.com/cache/category/334-morozivo.webp" },
                new { Id = 4, Name = "Заморожені продукти", Image = "https://src.zakaz.atbmarket.com/cache/category/Заморожені вироби.webp" }
            };

        return Ok(category);
    }
}
