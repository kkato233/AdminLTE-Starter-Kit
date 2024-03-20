using Company.WebApplication1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.WebApplication1.Services.Profile
{
    public class ProfileManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        IHttpContextAccessor _httpContextAccessor;

        private IdentityUser _currentUser;

        public ProfileManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IdentityUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

                return _currentUser;
            }
        }

        public bool IsHasPassword(IdentityUser user)
        {
            return _userManager.HasPasswordAsync(user).Result;
        }

        public bool IsEmailConfirmed(IdentityUser user)
        {
            return _userManager.IsEmailConfirmedAsync(user).Result;
        }
    }
}
