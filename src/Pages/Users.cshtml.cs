using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using asp_net_admin.Models;

namespace Company.WebApplication1.Pages
{
    public class UsersModel : PageModel
    {
        private readonly asp_net_admin.Models.AspNetAdminContext _context;

        public UsersModel(asp_net_admin.Models.AspNetAdminContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }
    }
}
