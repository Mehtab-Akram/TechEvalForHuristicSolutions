using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heuristics.TechEval.Web.Models
{
    public class CategoriesWithMemberCount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
    }
}