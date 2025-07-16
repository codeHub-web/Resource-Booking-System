using Internal_Resource_Booking_System.Data;
using Internal_Resource_Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// Alias the model to avoid naming conflict with the Booking namespace
using BookingModel = Internal_Resource_Booking_System.Models.Booking;

namespace Internal_Resource_Booking_System.Pages.Booking
{
    //Create Booking Logic
    public class CreateModel : PageModel
    {
        //Dependency Injection for Database Interaction
        private readonly AppDBContext _dBContext;

        public CreateModel(AppDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        //Binding form inputs to Booking
        [BindProperty]
        public BookingModel Booking { get; set; }

        public Resource Resource { get; set; }

        //Handles GET request to initialize the form
        public async Task<IActionResult> OnGetAsync(int resourceId)
        {
            Resource = await _dBContext.Resources.FindAsync(resourceId);

            if (Resource == null)
            {
                return NotFound();
            }

            Booking = new BookingModel
            {
                ResourceId = resourceId
            };

            return Page();
        }

        //Handles POST request to submit the form
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _dBContext.Bookings == null || Booking == null)
            {
                return Page();
            }

            //Check for booking time conflict
            bool hasConflict = await _dBContext.Bookings.AnyAsync(b =>
                b.ResourceId == Booking.ResourceId &&
                b.EndTime > Booking.StartTime &&
                b.StartTime < Booking.EndTime);

            if (hasConflict)
            {
                ModelState.AddModelError(string.Empty, "Resource is currently booked during the selected time.");
                return Page();
            }

            _dBContext.Bookings.Add(Booking);
            await _dBContext.SaveChangesAsync();

            return RedirectToPage(nameof(Index));
        }
    }
}
