using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCorePlayground.Web.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int CustomerStatusId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Dictionary<int, string> CustomerStatuses { get; set; }

        public SelectList CustomerStatusSelectList
        {
            get
            {
                if(CustomerStatuses == null)
                {
                    return null;
                }
                return new SelectList(CustomerStatuses, "Key", "Value", CustomerStatusId);
            }
        }

    }
}