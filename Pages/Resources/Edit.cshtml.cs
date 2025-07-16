using Internal_Resource_Booking_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Internal_Resource_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Internal_Resource_Booking_System.Pages.Resources
{
    public class EditModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public EditModel(AppDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Resource Resources { get; set; }

        public async Task<ActionResult> OnGetAsync(int? id) 
        {
            if (id == null || _dbContext.Resources == null) 
            {
                return NotFound();
            }
            var resource = await _dbContext.Resources.FirstOrDefaultAsync(p => p.Id == id);
            if (resource == null) 
            {
                return NotFound();
            }
            Resources = resource;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _dbContext.Resources.Update(Resources);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }

    }
}
