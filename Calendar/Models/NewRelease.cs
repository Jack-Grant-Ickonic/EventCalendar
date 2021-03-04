using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Models
{
    public class NewRelease
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a event start date.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a event end date.")]
        public DateTime EndDate { get; set; }
    }
}