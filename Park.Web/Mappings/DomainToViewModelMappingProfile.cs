using AutoMapper;
using Park.Entities;
using Park.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Park.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Customer, CustomerViewModel>();
            
        }
    }
    public class NullStringConverter : ITypeConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            return source ?? string.Empty;
        }
    } 
}