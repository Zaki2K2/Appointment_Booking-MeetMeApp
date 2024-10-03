using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MeetMeApp.Web.Data; // Adjust based on your project's structure
using MeetMeApp.Web.Models.Domain; // Adjust based on your project's structure

namespace MeetMeApp.Web.Pages.Admin.Meetings
{
    public class CreateMeetingModel : PageModel
    {
        private readonly MeetMeDbContext _context;

        public CreateMeetingModel(MeetMeDbContext context)
        {
            _context = context;
        }


        public PageResult OnGet()
        {
            //Meeting = new Information(); // Initialize the Meeting object
            return Page();
        }

        [BindProperty]
        public Information Meeting { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            
            // Business logic for creating an appointment
            Meeting.Info_id = Guid.NewGuid(); // Assign a new unique identifier
            Meeting.EntryRecord = DateTime.Now; // Set the entry record time
            Meeting.Deleted = false; // Set default value for 'Deleted' field

            // Save appointment to the database
            await _context.Informations.AddAsync(Meeting); // Add to context
            await _context.SaveChangesAsync(); // Save changes to the database

            // Redirect to a page that shows the list of meetings
            return RedirectToPage("/Admin/Meetings/MeetingList");
        }
    }
}

