using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MeetMeApp.Web.Data; // Adjust based on your project's structure
using MeetMeApp.Web.Models.Domain;
using Microsoft.EntityFrameworkCore; // Adjust based on your project's structure

namespace MeetMeApp.Web.Pages.Admin.Meetings
{
    public class MeetingListModel : PageModel
    {
        private readonly MeetMeDbContext _context;

        public MeetingListModel(MeetMeDbContext context)
        {
            _context = context;
        }

        public List<Information> Appointments { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch all appointments from the database
            Appointments = await _context.Informations
                .Where(a => !a.Deleted) // Exclude deleted appointments if necessary
                .ToListAsync();
        }
    }
}
