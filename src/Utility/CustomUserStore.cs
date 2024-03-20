using asp_net_admin.Models;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Company.WebApplication1.Data;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asp_net_admin.Utility
{
    public class CustomUserStore : IUserStore<IdentityUser>
        , IUserPasswordStore<IdentityUser>
        , IUserEmailStore<IdentityUser>
        , IUserPhoneNumberStore<IdentityUser>
        , IUserRoleStore<IdentityUser>
    {
        ApplicationDbContext dbContext;
        AspNetAdminContext db {  get
            {
                if (_db == null)
                {
                    _db = new AspNetAdminContext();
                }
                return _db;
            }
        }
        private AspNetAdminContext _db;
        public CustomUserStore(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //if (_db != null) { 
            //    _db.Dispose();
            //}
        }

        public async Task<IdentityUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            uint userN;
            if (uint.TryParse(userId, out userN))
            {
                var user = await db.Users.FindAsync(userN);
                if (user != null)
                {
                    return ToIdentityUser(user);
                }
            }

            return null;
        }

        IdentityUser ToIdentityUser(User user)
        {
            IdentityUser userInfo = new IdentityUser()
            {
                UserName = user.Name,
                Email = user.Email,
                Id = user.Id.ToString(),
                EmailConfirmed = user.EmailVerifiedAt != null,
                PasswordHash = user.Password,
            };

            return userInfo;
        }

        public async Task<IdentityUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = db.Users.Where(r => r.Name == normalizedUserName).FirstOrDefault();
            if (user != null)
            {
                return ToIdentityUser(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<string?> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return user.PasswordHash;
        }

        public async Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return user.Id.ToString();
        }

        public async Task<string?> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return user?.UserName;
        }

        public async Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user.PasswordHash != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SetNormalizedUserNameAsync(IdentityUser user, string? normalizedName, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            // 無視して何もしない
        }

        public async Task SetPasswordHashAsync(IdentityUser user, string? passwordHash, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            // 無視して何もしない
        }

        public async Task SetUserNameAsync(IdentityUser user, string? userName, CancellationToken cancellationToken)
        {
            uint userId = uint.Parse(user.Id);
            var updUser = db.Users.Find(userId);
            if (updUser != null)
            {
                updUser.Username = userName;
                db.Update(updUser);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            //無視して何もしない
            return IdentityResult.Success;
        }

        public async Task SetEmailAsync(IdentityUser user, string? email, CancellationToken cancellationToken)
        {
            uint userId = uint.Parse(user.Id);
            var updUser = db.Users.Find(userId);
            if (updUser != null)
            {
                updUser.Email = email;
                db.Update(updUser);
                await db.SaveChangesAsync();
            }
        }

        public async Task<string?> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            uint userId = uint.Parse(user.Id);
            var dbUser = await db.Users.FindAsync(userId);
            return dbUser?.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            uint userId = uint.Parse(user.Id);
            var dbUser = await db.Users.FindAsync(userId);
            return dbUser?.EmailVerifiedAt != null;
        }

        public async Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var user = db.Users.Where(r => r.Email == normalizedEmail).FirstOrDefault();
            if (user != null)
            {
                return ToIdentityUser(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<string?> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetNormalizedEmailAsync(IdentityUser user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            // 無視してなにもしない
        }

        public async Task SetPhoneNumberAsync(IdentityUser user, string? phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            uint userId = uint.Parse(user.Id);

            var user1 = await db.Users.Where(r => r.Id == userId)
                .Include(r => r.Roles)
                .FirstOrDefaultAsync();
            if (user1 != null)
            {
                var roles = db.Users
                    .Where(r => r.Id == userId)
                    .SelectMany(r => r.Roles)
                    .Select(r => r.Name).ToList();

                if (user1.Role != null)
                {
                    roles.Add(user1.Role.Name);
                }

                return roles;
            }

            return new List<string>();
        }

        public async Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = await db.Roles.Where(r => r.Name == roleName).FirstOrDefaultAsync();
            if (role != null)
            {
                if (db.Users.Where(r => r.Roles.Contains(role)).Any())
                {
                    return true;
                }
            }
            return false;
        }

        public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
