using Park.Data.Infrastructure;
using Park.Data.Repositories;
using Park.Entities;
using Park.Services.Abstract;
using Park.ViewModel;
using Park.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Park.Web.Areas.Common.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonController : ApiController
    {
        private readonly ICommonService _icommonservive;
        private readonly IUnitOfWork _unitOfWork;
        public CommonController(
            ICommonService icommonservive,
            IUnitOfWork unitOfWork) 
        {
            _icommonservive = icommonservive;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetEmployeeList")]
        public PaginationSet<CustomerViewModel> GetEmployeeList(HttpRequestMessage request, int? page, int? pageSize, int? filterCustomersColumn, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;
            int columnfilter = Convert.ToInt16(filterCustomersColumn);
            CustomerGridViewModel responseData = _icommonservive.GetEmployeeList(currentPage, currentPageSize, columnfilter, filter);
            PaginationSet<CustomerViewModel> pagedSet = new PaginationSet<CustomerViewModel>()
            {
                Page = currentPage,
                TotalCount = responseData.totalCount,
                TotalPages = (int)Math.Ceiling((decimal)responseData.totalCount / currentPageSize),
                Items = responseData.customerList
            };
            return pagedSet; 
        }
        [HttpPost]
        [Route("DeleteEmployee")]
        public int DeleteEmployee(HttpRequestMessage request, [FromBody]int customerId)
        {
            return _icommonservive.DeleteEmployee(customerId);
        }

        [HttpPost]
        [Route("GetEmployeeDetailsById")]
        public CustomerViewModel GetEmployeeDetailsById(HttpRequestMessage request, [FromBody]int customerId)
        {
            return _icommonservive.GetEmployeeDetailsById(customerId);
        }


        [HttpPost]
        [Route("country")]
        public List<CountryViewModel> GetAllCountry(HttpRequestMessage request)
        { 
           return _icommonservive.GetCountryList();  
        }
        [HttpPost]
        [Route("state")]
        public List<StateViewModel> GetState(HttpRequestMessage request, [FromBody]long countryId)
        {
            return _icommonservive.GetStateByCountryId(countryId);
        }
        [HttpPost]
        [Route("getstatescity")]
        public List<CityViewModel> getCity(HttpRequestMessage request, [FromBody] long stateId)
        {
            return _icommonservive.GetCityByCountryId(stateId);
        }
        [Route("images/upload")]
        public ProfilePicViewModel Post(HttpRequestMessage request)
        { 
                ProfilePicViewModel pod = new ProfilePicViewModel();
                var httpRequest = HttpContext.Current.Request;
                HttpResponseMessage response = null;
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var FolderPath = "Images/ProfilePic/";
                    var FileName = Guid.NewGuid() + ".Jpeg";
                    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/" + FolderPath))) ;
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + FolderPath));
                    var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + FolderPath + FileName);
                    postedFile.SaveAs(filePath);
                    pod = new ProfilePicViewModel()
                    {
                        AttachmentPath = FolderPath + FileName
                    };
                }
                return pod;
        }

        [HttpPost]
        [Route("saveCustomer")]
        public int saveCustomer(HttpRequestMessage request, [FromBody] Customer customer)
        {
            if (customer.ID == 0)
                return _icommonservive.AddEmployee(customer);
            else
                return _icommonservive.UpdateEmployee(customer);
        }

    }
}
