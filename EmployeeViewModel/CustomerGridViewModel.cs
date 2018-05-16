using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.ViewModel
{
    public class CustomerGridViewModel
    {
        public List<CustomerViewModel> customerList { get; set; }
        public int totalCount { get; set; }
    }
}
