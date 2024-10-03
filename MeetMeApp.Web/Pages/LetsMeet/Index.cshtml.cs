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
    public class IndexModel : PageModel
    {
        private readonly MeetMeApp.Web.Data.MeetMeDbContext _context;

        public IndexModel(MeetMeApp.Web.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        public IList<Information> Information { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Information = await _context.Informations.ToListAsync();
        }
    }
}
