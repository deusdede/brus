using Scheduler.Examples.BindToList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TesteWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private const string AppointmentsKey = "Telerik.Web.Examples.Scheduler.BindToList.CS.Apts";

        private List<AppointmentInfo> Appointments
        {
            get
            {
                List<AppointmentInfo> sessApts = Session[AppointmentsKey] as List<AppointmentInfo>;
                if (sessApts == null)
                {
                    sessApts = new List<AppointmentInfo>();
                    Session[AppointmentsKey] = sessApts;
                }

                return sessApts;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                Session.Remove(AppointmentsKey);

                InitializeResources();
                InitializeAppointments();
            }

            //RadScheduler1.DataSource = Appointments;
        }

        protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
        {
            Appointments.Add(new AppointmentInfo(e.Appointment));
        }

        protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {
            AppointmentInfo ai = FindById(e.ModifiedAppointment.ID);


            RecurrenceRule rrule;

            if (RecurrenceRule.TryParse(e.ModifiedAppointment.RecurrenceRule, out rrule))
            {
                rrule.Range.Start = e.ModifiedAppointment.Start;
                rrule.Range.EventDuration = e.ModifiedAppointment.End - e.ModifiedAppointment.Start;
                TimeSpan startTimeChange = e.ModifiedAppointment.Start - e.Appointment.Start;
                for (int i = 0; i < rrule.Exceptions.Count; i++)
                {
                    rrule.Exceptions[i] = rrule.Exceptions[i].Add(startTimeChange);
                }
                e.ModifiedAppointment.RecurrenceRule = rrule.ToString();
            }

            ai.CopyInfo(e.ModifiedAppointment);
        }

        protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            Appointments.Remove(FindById(e.Appointment.ID));
        }

        private void InitializeResources()
        {
            ResourceType resType = new ResourceType("User");
            resType.ForeignKeyField = "UserID";

            RadScheduler1.ResourceTypes.Add(resType);
            RadScheduler1.Resources.Add(new Resource("User", 1, "Alex"));
            RadScheduler1.Resources.Add(new Resource("User", 2, "Bob"));
            RadScheduler1.Resources.Add(new Resource("User", 3, "Charlie"));
        }

        private void InitializeAppointments()
        {
            DateTime start = DateTime.UtcNow.Date;
            start = start.AddHours(6);
            Appointments.Add(new AppointmentInfo("Take the car to the service", start, start.AddHours(1), string.Empty, null, new Reminder(30).ToString(), 1));
            Appointments.Add(new AppointmentInfo("Meeting with Alex", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 2));

            start = start.AddDays(-1);
            DateTime dayStart = RadScheduler1.UtcDayStart(start);
            Appointments.Add(new AppointmentInfo("Bob's Birthday", dayStart, dayStart.AddDays(1), string.Empty, null, string.Empty, 1));
            Appointments.Add(new AppointmentInfo("Call Charlie about the Project", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 2));

            start = start.AddDays(2);
            Appointments.Add(new AppointmentInfo("Get the car from the service", start.AddHours(2), start.AddHours(3), string.Empty, null, string.Empty, 1));
        }

        private AppointmentInfo FindById(object ID)
        {
            foreach (AppointmentInfo ai in Appointments)
            {
                if (ai.ID.Equals(ID))
                {
                    return ai;
                }
            }

            return null;
        }
    }
}

namespace Scheduler.Examples.BindToList
{
    class AppointmentInfo
    {
        private readonly string _id;
        private string _subject;
        private DateTime _start;
        private DateTime _end;
        private string _recurrenceRule;
        private string _recurrenceParentId;
        private string _reminder;
        private int? _userID;

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        public string RecurrenceRule
        {
            get
            {
                return _recurrenceRule;
            }
            set
            {
                _recurrenceRule = value;
            }
        }

        public string RecurrenceParentID
        {
            get
            {
                return _recurrenceParentId;
            }
            set
            {
                _recurrenceParentId = value;
            }
        }

        public int? UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

        public string Reminder
        {
            get
            {
                return _reminder;
            }
            set
            {
                _reminder = value;
            }
        }

        private AppointmentInfo()
        {
            _id = Guid.NewGuid().ToString();
        }

        public AppointmentInfo(string subject, DateTime start, DateTime end,
            string recurrenceRule, string recurrenceParentID, string reminder, int? userID) : this()
        {
            _subject = subject;
            _start = start;
            _end = end;
            _recurrenceRule = recurrenceRule;
            _recurrenceParentId = recurrenceParentID;
            _reminder = reminder;
            _userID = userID;
        }

        public AppointmentInfo(Appointment source) : this()
        {
            CopyInfo(source);
        }

        public void CopyInfo(Appointment source)
        {
            Subject = source.Subject;
            Start = source.Start;
            End = source.End;
            RecurrenceRule = source.RecurrenceRule;
            if (source.RecurrenceParentID != null)
            {
                RecurrenceParentID = source.RecurrenceParentID.ToString();
            }

            if (!String.IsNullOrEmpty(Reminder))
            {
                Reminder = source.Reminders[0].ToString();
            }

            Resource user = source.Resources.GetResourceByType("User");
            if (user != null)
            {
                UserID = (int?)user.Key;
            }
            else
            {
                UserID = null;
            }
        }
    }
}