using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetMeApp.Web.Data;
using MeetMeApp.Web.Models.Domain;

namespace MeetMeApp.Web.Pages.LetsMeet
{
    public class EditModel : PageModel
    {
        private readonly MeetMeApp.Web.Data.MeetMeDbContext _context;

        public EditModel(MeetMeApp.Web.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Information Information { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information =  await _context.Informations.FirstOrDefaultAsync(m => m.Info_id == id);
            if (information == null)
            {
                return NotFound();
            }
            Information = information;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(Information.Info_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InformationExists(Guid id)
        {
            return _context.Informations.Any(e => e.Info_id == id);
        }
    }
}
