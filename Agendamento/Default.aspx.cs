using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Collections.Generic;


public partial class Default : System.Web.UI.Page 
{
    private const string AppointmentsKey =
                    "Telerik.Examples.Scheduler.BindToList_Apts";
    private List<AppointmentInfo> Appointments
    {
        get
        {
            List<AppointmentInfo> sessApts =
                      Session[AppointmentsKey] as List<AppointmentInfo>;
            if (sessApts == null)
            {
                sessApts = new List<AppointmentInfo>();
                Session[AppointmentsKey] = sessApts;
            }
            return sessApts;
        }
    }
    private List<RoomInfo> Rooms
    {
        get
        {
            List<RoomInfo> roomList = new List<RoomInfo>();
            roomList.Add(new RoomInfo(1, "Margaret Morrison Main Room"));
            roomList.Add(new RoomInfo(2, "Black Auditorium"));
            roomList.Add(new RoomInfo(3, "Doherty Auditorium"));
            return roomList;
        }
    }

    private AppointmentInfo FindById(string ID)
    {
        foreach (AppointmentInfo ai in Appointments)
        {
            if (ai.ID == ID)
            {
                return ai;
            }
        }
        return null;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove(AppointmentsKey);
            RadScheduler1.DataKeyField = "ID";
            RadScheduler1.DataStartField = "Start";
            RadScheduler1.DataEndField = "End";
            RadScheduler1.DataSubjectField = "Subject";
            RadScheduler1.DataRecurrenceField = "RecurrenceRule";
            RadScheduler1.DataRecurrenceParentKeyField = "RecurrenceParentID";
            ResourceType rt = new ResourceType("Room");
            rt.DataSource = Rooms;
            rt.KeyField = "RoomNo";
            rt.ForeignKeyField = "RoomNo";
            rt.TextField = "RoomName";
            RadScheduler1.ResourceTypes.Add(rt);
        }
        RadScheduler1.DataSource = Appointments;
    }

    protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        Appointments.Add(new AppointmentInfo(e.Appointment));
    }

    protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
        AppointmentInfo ai = FindById(e.ModifiedAppointment.ID.ToString());
        ai.CopyInfo(e.ModifiedAppointment);
    }

    protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        Appointments.Remove(FindById(e.Appointment.ID.ToString()));
    }
}

class AppointmentInfo
{
    private string id;
    private string subject;
    private DateTime start;
    private DateTime end;
    private string recurParentID;
    private string recurData;
    private int room;

    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }
    public DateTime Start
    {
        get { return start; }
        set { start = value; }
    }
    public DateTime End
    {
        get { return end; }
        set { end = value; }
    }
    public string RecurrenceRule
    {
        get { return recurData; }
        set { recurData = value; }
    }
    public string RecurrenceParentID
    {
        get { return recurParentID; }
        set { recurParentID = value; }
    }
    public int RoomNo
    {
        get { return room; }
        set { room = value; }
    }
    private AppointmentInfo()
    {
        this.id = Guid.NewGuid().ToString();
    }
    public AppointmentInfo(string subject, DateTime start, DateTime end)
        : this()
    {
        this.subject = subject;
        this.start = start;
        this.end = end;
    }
    public AppointmentInfo(Appointment source)
        : this()
    {
        CopyInfo(source);
    }
    public void CopyInfo(Appointment source)
    {
        subject = source.Subject;
        start = source.Start;
        end = source.End;
        recurData = source.RecurrenceRule;
        if (source.RecurrenceParentID != null)
            recurParentID = source.RecurrenceParentID.ToString();
        Resource r = source.Resources.GetResourceByType("Room");
        if (r != null)
            room = (int)r.Key;
    }
}
class RoomInfo
{
    private int id;
    private string name;
    public int RoomNo
    {
        get { return id; }
    }
    public string RoomName
    {
        get { return name; }
    }
    public RoomInfo(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}