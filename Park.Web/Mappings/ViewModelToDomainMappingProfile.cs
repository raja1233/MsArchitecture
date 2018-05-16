using AutoMapper;
using Park.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
             
        }
    }
}