using Park.Data.Repositories;
using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Extensions
{
    public static class CustomerExtensions
    {
        public static bool UserExists(this IEntityBaseRepository<Customer> customersRepository, string email, string identityCard)
        {
            bool _userExists = false;

            _userExists = customersRepository.GetAll()
                .Any(c => c.Email.ToLower() == email);

            return _userExists;
        }
         
    }
}
