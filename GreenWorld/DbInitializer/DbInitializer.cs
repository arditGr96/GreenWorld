using GreenWorld.Data;
using GreenWorld.Helpers;
using GreenWorld.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace GreenWorld.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly AppDbContext _con;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;

        public DbInitializer(
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext con)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _con = con;
        }


        public void Initialize()
        {
            _con.Database.EnsureCreated();
            if (_con.Roles.Any(r => r.Name == Sd.RoleAdmin))
            {
                return;
            }

            _roleManager.CreateAsync(new IdentityRole(Sd.RoleAdmin)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new Users
            {
                UserName = "ag",
                FirstName="Ardit",
                LastName="Grajcevci",
                Email = "a@gmail.com",
                PhoneNumber = "049111111",
            }, "Test123!").GetAwaiter().GetResult();
        }
    }
}
