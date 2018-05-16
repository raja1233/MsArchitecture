using Park.Entities;
using Park.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Services.Abstract
{
    public interface ICommonService
    {
        CustomerGridViewModel GetEmployeeList(int currentPage, int currentPageSize, int filterCustomersColumn, string filter = null);
        int DeleteEmployee(int customerId=0);
        CustomerViewModel GetEmployeeDetailsById(int customerId = 0);
        List<CountryViewModel> GetCountryList();
        List<StateViewModel> GetStateByCountryId(long countryId);
        List<CityViewModel> GetCityByCountryId(long stateId);
        int AddEmployee(Customer customerViewModel);
        int UpdateEmployee(Customer customerViewModel);
    }
}
