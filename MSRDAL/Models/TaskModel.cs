using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRDAL.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual List<SubTaskModel> SubTasks { get; set; }
    }
    public class SubTaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public bool IsActive { get; set; }
        public virtual List<JiraTicketModel> JiraTickets { get; set; }
    }
    public class JiraTicketModel
    {
        public int Id { get; set; }
        public int SubTaskId { get; set; }
        public int JiraTicketId { get; set; }
    }
    public class PrivateTaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PrivateType { get; set; }
        public string Icon { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual List<SubTaskModel> SubTasks { get; set; }
    }
}
