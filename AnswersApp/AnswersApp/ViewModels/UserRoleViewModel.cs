using AnswersApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnswersApp.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRole MyUserRole { get; set; }    
        Tools.Crypto MyCrypto { get; set; }

        public UserRoleViewModel()
        {
            MyCrypto = new Tools.Crypto();
            MyUserRole = new UserRole();
        }


        public async Task<List<UserRole>> GetUserRoles()
        {
            return await MyUserRole.GetUserRolesList();
        }

    }
}
