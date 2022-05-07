using System;
using System.ComponentModel;

namespace Budget.Mvc.Mac.Models.ViewModels
{
	public class FilterParametersViewModel
	{
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        [DisplayName("Start Date")]
        public string? StartDate { get; set; }

        [DisplayName("End Date")]
        public string? EndDate { get; set; }

        public List<Category>? Categories { get; set; }
    }
}

