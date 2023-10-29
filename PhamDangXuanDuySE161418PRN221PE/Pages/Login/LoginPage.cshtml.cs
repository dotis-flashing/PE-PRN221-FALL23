using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace WebRazor.Pages;

public class LoginPageModel : PageModel
{
    [BindProperty]
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    public string Password { get; set; }


    private readonly IMemeberService _memeberService;

    public LoginPageModel(IMemeberService memeberService)
    {
        _memeberService = memeberService;
    }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var admin = await _memeberService.Login(Email, Password);
                if (admin.Role.Equals(3))
                {   
                    HttpContext.Session.SetInt32("role",3);
                    //HttpContext.Session.SetInt32("CustomerId", admin./*CustomerId*/);
                    return Redirect("/UIROLE");
                    //ViewData["Message"] = "Dang nhap thanh cong";
                }
                //else if (admin == false)
                //{
                //    var customer = _customerService.CustomerLogin(Email, Password);
                //    HttpContext.Session.SetString("role", "customer");
                //    HttpContext.Session.SetString("customerId", customer.CustomerId.ToString());

                //    return Redirect("/uirole");
                //}
                else
                {
                    ViewData["Message"] = "Khog co quyen dang nhap";
                }
                return Page();
            }
        }
        catch (Exception ex)
        {
            ViewData["Message"] = ex.Message.ToString();
            ViewData["Email"] = Email;
            return Page();

        }
    }
}


