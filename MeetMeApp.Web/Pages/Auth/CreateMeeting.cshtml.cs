using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetMeApp.Web.Data;
using MeetMeApp.Web.Models.Domain;

namespace MeetMeApp.Web.Pages.Admin
{
    public class CreateMeetingModel : PageModel
    {
        private readonly MeetMeApp.Web.Data.MeetMeDbContext _context;

        public CreateMeetingModel(MeetMeApp.Web.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Information Information { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Informations.Add(Information);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
