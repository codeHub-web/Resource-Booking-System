using Internal_Resource_Booking_System.Data;
using Internal_Resource_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingModel = Internal_Resource_Booking_System.Models.Booking;


namespace Internal_Resource_Booking_System.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public BookingModel Booking { get; set; }
        public Resource Resource { get; set; }

        public async Task<IActionResult> OnGetAsync(int resourceId)
        {
            Resource = await _dbContext.Resources.FindAsync(resourceId);
            {
                if (Resource == null)
                    return NotFound();
            }

            Booking = new Internal_Resource_Booking_System.Models.Booking
            {
                ResourceId = resourceId,
            };
        return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            //Detects conflicting bookings, and shows error
            Boolean hasConflict = await _dbContext.Bookings.AnyAsync(b =>
            b.ResourceId == Booking.ResourceId &&
            b.EndTime > Booking.StartTime &&
            b.StartTime < Booking.EndTime);

            if (hasConflict)
            {
                ModelState.AddModelError(string.Empty, "Resource is currently booked");
                return Page();
            }

            _dbContext.Bookings.Add(Booking);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
        
        
    }
}
