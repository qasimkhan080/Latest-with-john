//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSRDAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubTasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<JiraTickets> JiraTickets { get; set; }
        public virtual Tasks Tasks { get; set; }
    }
}
