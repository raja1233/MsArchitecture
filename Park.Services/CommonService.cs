using AutoMapper;
using Newtonsoft.Json;
using Park.Data.Infrastructure;
using Park.Data.Repositories;
using Park.Entities;
using Park.Services.Abstract;
using Park.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Park.Services
{
    public class CommonService : ICommonService
    {
        private readonly IEntityBaseRepository<Customer> _userRepository;
        private readonly IEntityBaseRepository<Country> _countryRepository;
        private readonly IEntityBaseRepository<State> _stateRepository;
        private readonly IEntityBaseRepository<City> _cityRepository; 
        private readonly IUnitOfWork _unitOfWork;
        public CommonService(
            IEntityBaseRepository<Customer> userRepository,
            IEntityBaseRepository<Country> countryRepository,
            IEntityBaseRepository<State> stateRepository,
            IEntityBaseRepository<City> cityRepository, 
            IUnitOfWork unitOfWork
                            )

        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository; 
            _unitOfWork = unitOfWork;
        }
        public CustomerGridViewModel GetEmployeeList(int currentPage, int currentPageSize, int filterCustomersColumn, string filter = null)
        {
            CustomerGridViewModel customerViewModel = new CustomerGridViewModel(); 
            try
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    var tempData = _userRepository.GetAll()
                            //.OrderBy(c => c.ID)
                            //.Skip(currentPage * currentPageSize)
                            //.Take(currentPageSize)
                            .ToList();
                    /////
                    if (filterCustomersColumn == 1)
                        tempData = tempData.Where(c => c.Name.ToLower().Contains(filter)).ToList();
                    else if (filterCustomersColumn == 2)
                        tempData = tempData.Where(c => c.Phone.ToLower().Contains(filter)).ToList();
                    else  if (filterCustomersColumn == 3)
                        tempData = tempData.Where(c => c.Email.ToLower().Contains(filter)).ToList();
                    else  if (filterCustomersColumn == 4)
                    {
                        try
                        {
                            var time = Convert.ToDateTime(filter);
                            tempData = tempData.Where(c => c.DOB.GetValueOrDefault() == time).ToList();
                        }
                        catch (Exception ex)
                        {
                            
                            throw ex;
                        }
                       
                    }
                    else  if (filterCustomersColumn == 5)
                        tempData = tempData.Where(c => c.City.CityName.ToLower().Contains(filter)).ToList();

                    ////
                    customerViewModel.customerList = (from c in tempData
                                                      select new CustomerViewModel
                                                      {
                                                          ID=c.ID,
                                                          Name = c.Name,
                                                          Email = c.Email,
                                                          Phone = c.Phone,
                                                          DOB = c.DOB,
                                                          CityId = c.CityId,
                                                          ProfileImageURL = c.ProfileImageURL,
                                                          IsDeleted = c.IsDeleted,
                                                          CityName = c.City.CityName,
                                                       })
                                                      .ToList();

                    customerViewModel.totalCount = _userRepository.FindBy(c => c.Name.ToLower().Contains(filter))
                            .Skip(currentPage * currentPageSize)
                            .Take(currentPageSize).Count();
                }
                else
                {
                    var tempData = _userRepository.GetAll()
                             .OrderBy(c=>c.ID)
                             .Skip(currentPage * currentPageSize)
                             .Take(currentPageSize)
                             .ToList();
                    customerViewModel.customerList = (from c in tempData
                                                      select new CustomerViewModel
                                                      {
                                                          ID = c.ID,
                                                          Name = c.Name,
                                                          Email = c.Email,
                                                          Phone = c.Phone,
                                                          DOB = c.DOB,
                                                          CityId = c.CityId,
                                                          ProfileImageURL = c.ProfileImageURL,
                                                          IsDeleted = c.IsDeleted,
                                                          CityName = c.City.CityName,
                                                      })
                                                     .ToList();
                    customerViewModel.totalCount = _userRepository.GetAll().Count();

                }  
            }
            catch (Exception)
            {
                
            }
            return customerViewModel;
        }

        public int DeleteEmployee(int customerId = 0)
        {
           var tempdataToBeDeleted =_userRepository.GetSingle(customerId);
           try
           {
               _userRepository.SoftDelete(tempdataToBeDeleted);
               _unitOfWork.Commit();
               return 1;
           }
           catch (Exception)
           {

               return 0;
           }
        }
        public CustomerViewModel GetEmployeeDetailsById(int customerId = 0)
        {
            CustomerViewModel customerViewModel= new CustomerViewModel ();
            try
            {
                var tempData = _userRepository.FindBy(c => c.ID == customerId).ToList();
                customerViewModel = (from c in tempData
                                                  select new CustomerViewModel
                                                  {
                                                      ID = c.ID,
                                                      Name = c.Name,
                                                      Email = c.Email,
                                                      Phone = c.Phone,
                                                      DOB = c.DOB,
                                                      CityId = c.CityId,
                                                      CountryId = c.City.State.CountryId,
                                                      StateId = c.City.StateId,
                                                      ProfileImageURL = c.ProfileImageURL,
                                                      IsDeleted = c.IsDeleted,
                                                      CityName = c.City.CityName,
                                                  }).FirstOrDefault();
            }
            catch (Exception)
            {
                new CustomerViewModel();
               
            }
            return customerViewModel;
        }
        public List<CountryViewModel> GetCountryList()
        {
            List<CountryViewModel> countryViewModel = new List<CountryViewModel>();
            try
            {
                var tempData = _countryRepository.GetAll().ToList();
                countryViewModel = (from c in tempData
                                     select new CountryViewModel
                                     {
                                         ID = c.ID,
                                         CountryName = c.CountryName, 
                                     }).ToList(); 
            }
            catch (Exception)
            {
                return new List<CountryViewModel>();
            }
            return countryViewModel;
        }
        public List<StateViewModel> GetStateByCountryId(long countryId)
        {
            List<StateViewModel> stateViewModel = new List<StateViewModel>();
            try
            {
                var tempData = _stateRepository.FindBy(x => x.CountryId == countryId).ToList();
                stateViewModel = (from c in tempData
                                    select new StateViewModel
                                    {
                                        ID = c.ID,
                                        CountryId=c.CountryId,
                                        StateName=c.StateName,
                                        CountryName=c.Country.CountryName
                                    }).ToList();
            }
            catch (Exception)
            {
                return new List<StateViewModel>();
            }
            return stateViewModel;
        }
        public List<CityViewModel> GetCityByCountryId(long stateId)
        {
            List<CityViewModel> cityViewModel = new List<CityViewModel>();
            try
            {
                var tempData = _cityRepository.FindBy(x => x.StateId == stateId).ToList();
                cityViewModel = (from c in tempData
                                  select new CityViewModel
                                  {
                                      ID = c.ID,
                                      CityName = c.CityName,
                                      StateName = c.State.StateName,
                                      StateId=c.StateId,
                                      CountryName = c.State.Country.CountryName
                                  }).ToList();
            }
            catch (Exception)
            {
                return new List<CityViewModel>();
            }
            return cityViewModel;
        }

        public int AddEmployee(Customer customerViewModel)
        {
           
            try
            {
                customerViewModel.DOB = Convert.ToDateTime(customerViewModel.DOB).Date;
                _userRepository.Add(customerViewModel);
                _unitOfWork.Commit();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            } 
        }
        public int UpdateEmployee(Customer customerViewModel)
        {

            try
            {
               var oldData= _userRepository.FindBy(x => x.ID == customerViewModel.ID).FirstOrDefault();
               _userRepository.Edit(oldData, customerViewModel);
                _unitOfWork.Commit();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
