using System;
using System.Collections.Generic;

#nullable disable

// this file was auto-generated by the Scaffold-DbContext command line tool

namespace TextEmAllChallenge.Entities
{
    public partial class CourseInstructor
    {
        public int CourseId { get; set; }
        public int PersonId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
