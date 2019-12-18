using CSBI_test.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSBI_test.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ActivityStatus { get; set; }
        public Manager DelegatedManager { get; set; }
    }

    public class CloseTaskModel
    {
        public string ManagerMail { get; set; }
        public int ClosingTaskId { get; set; }
    }
}
