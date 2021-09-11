using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Sporty.Data;
using Sporty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Sporty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SportyContext _context;
        private readonly IConfiguration Configuration;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(SportyContext context, IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _context = context;
            Configuration = configuration;
            _logger = logger;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}
