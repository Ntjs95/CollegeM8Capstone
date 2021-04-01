using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Schedule
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<ScheduleItem> schedule { get; set; }

        internal static async Task<string> UpdateSchedule(CollegeM8Context db, Term term)
        {
            ScheduleService scheduleService = new ScheduleService(db);
            Schedule scheduleCreateData = new Schedule();
            scheduleCreateData.userId = term.UserId;
            scheduleCreateData.startDate = term.StartDate;
            scheduleCreateData.endDate = term.EndDate;
            scheduleService.GenerateSchedule(scheduleCreateData);
            return null;
        }

        internal static async Task<string> UpdateSchedule(CollegeM8Context db, string termId)
        {
            Term term = db.Term.FirstOrDefault(t => t.TermId == termId);
            ScheduleService scheduleService = new ScheduleService(db);
            Schedule scheduleCreateData = new Schedule();
            scheduleCreateData.userId = term.UserId;
            scheduleCreateData.startDate = term.StartDate;
            scheduleCreateData.endDate = term.EndDate;
            scheduleService.GenerateSchedule(scheduleCreateData);
            return null;
        }
    }

}
