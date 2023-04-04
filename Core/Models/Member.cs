using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heuristics.TechEval.Core.Models {

	public class Member {

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime LastUpdated { get; set; }

        // Navigation property
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}


