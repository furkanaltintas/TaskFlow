using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}