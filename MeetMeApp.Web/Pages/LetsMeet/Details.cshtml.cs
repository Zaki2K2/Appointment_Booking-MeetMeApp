using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetMeApp.Web.Data;
using MeetMeApp.Web.Models.Domain;

namespace MeetMeApp.Web.Pages.LetsMeet
{
    public class DetailsModel : PageModel
    {
        private readonly MeetMeApp.Web.Data.MeetMeDbContext _context;

        public DetailsModel(MeetMeApp.Web.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        public Information Information { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Informations.FirstOrDefaultAsync(m => m.Info_id == id);
            if (information == null)
            {
                return NotFound();
            }
            else
            {
                Information = information;
            }
            return Page();
        }
    }
}
