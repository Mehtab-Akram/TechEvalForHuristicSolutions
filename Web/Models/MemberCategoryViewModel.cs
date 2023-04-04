using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heuristics.TechEval.Web.Models
{
    public class MemberCategoryViewModel
    {
        public List<Member> Members { get; set; }
        public List<Category> Categories { get; set; }
    }
}