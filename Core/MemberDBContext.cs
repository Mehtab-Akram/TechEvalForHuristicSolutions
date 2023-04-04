using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heuristics.TechEval.Core
{
    public class MemberDBContext : DbContext
    {
        public MemberDBContext() { }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
