using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            // This will not give desired result.                                                          
            // Session["timeout"] = DateTime.Now.AddMinutes(120).ToString(); 
            String date = DateTime.Now.ToString();

            RangeValidator1.MinimumValue = date;
            timer1.Enabled = false;
            BindTime();
        }
       // Response.Write(DateTime.Now);
    }

    protected void timer1_Tick(object sender, EventArgs e)
    {
        string sf = ddl.SelectedValue.ToString() ;
        string tt = TextBox1.Text + " " + sf;
        
       
        DateTime d1 = TextBox1.Text != string.Empty ? Convert.ToDateTime(tt) : DateTime.MinValue;
       
        
        TimeSpan tspan = d1 - DateTime.Now;
        tspan = new TimeSpan(tspan.Days, tspan.Hours, tspan.Minutes,tspan.Seconds);
        //        remaining.Seconds);
        if (tspan.TotalSeconds < 0)
            tspan = TimeSpan.Zero;

        Label1.Text = tspan.ToString();
       
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        timer1.Enabled = true;

        string ssd= ddl.SelectedValue.ToString();
        string dsf = TextBox1.Text + " " + ssd;


        DateTime d2 = TextBox1.Text != string.Empty ? Convert.ToDateTime(dsf) : DateTime.MinValue;
        if (d2 < DateTime.Now)
        {
            Response.Write("sdjf");
        }
               
    }


    private void BindTime()
    {
       
                                         
        // Set the start time (00:00 means 12:00 AM)
        DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm",null);
        // Set the end time (23:55 means 11:55 PM
        DateTime EndTime = DateTime.ParseExact("23:59", "HH:mm", null);
        //Set 5 minutes interval
        TimeSpan Interval = new TimeSpan(0,1,0);
        //To set 1 hour interval
        //TimeSpan Interval = new TimeSpan(1, 0, 0);           
        ddl.Items.Clear();
        //ddlTimeTo.Items.Clear();
      

        while (StartTime <= EndTime)
        {
            ddl.Items.Add(StartTime.ToString("hh:mm tt"));
            //ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
            StartTime = StartTime.Add(Interval);
        }
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        //ddlTimeTo.Items.Insert(0, new ListItem("--Select--", "0"));
    }

}