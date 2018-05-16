using Park.Web.Infrastructure.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park.Web.Models
{
    [Bind(Exclude = "UniqueKey")]
    public class CustomerViewModel : IValidatableObject
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public Nullable<long> CityId { get; set; }
        public string ProfileImageURL { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CustomerViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}