using Internal_Resource_Booking_System.Data;
using Internal_Resource_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Internal_Resource_Booking_System.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext  _dbContext;

        public IndexModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Resource> Resources { get; set; } 

        public async Task OnGetAsync()
        {
            if(_dbContext.Resources != null) 
            {
                Resources = await _dbContext.Resources.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var resource = await _dbContext.Resources.FindAsync(id);
            if (resource != null)
            {
                _dbContext.Resources.Remove(resource);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }

    }
}
