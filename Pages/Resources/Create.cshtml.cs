using Internal_Resource_Booking_System.Data;
using Internal_Resource_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Internal_Resource_Booking_System.Pages.Resources
{
    //Create Resource Logic
    public class CreateModel : PageModel
    {
        //Dependency Injection for Database Interaction
        private readonly AppDBContext _dBContext;

        public CreateModel(AppDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public void OnGet()
        {
        }

        //Binding form inputs to Resource
        [BindProperty]
        public Resource Resources { get; set; }

        public async Task<IActionResult> OnPost() 
        {
            if (!ModelState.IsValid || _dBContext.Resources == null || Resources == null) 
            {
                return Page();
            }


            _dBContext.Resources.Add(Resources);
            await _dBContext.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
