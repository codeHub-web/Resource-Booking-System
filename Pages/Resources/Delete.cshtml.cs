using Internal_Resource_Booking_System.Data;
using Internal_Resource_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Internal_Resource_Booking_System.Pages.Resources
{
    public class DeleteModel : PageModel
    {
        private AppDBContext _dbContext;

        public DeleteModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Resource Resources { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }
            var resource = await _dbContext.Resources.FirstOrDefaultAsync(r => r.Id == id);
            
            if (resource == null) { 
                return NotFound();
            }
            Resources = resource;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resource = await _dbContext.Resources.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }
            Resources = resource;
            _dbContext.Remove(Resources);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
