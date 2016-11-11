using AutoMapper;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using uStora.Data;
using uStora.Model.Models;
using uStora.Web.Hubs;

namespace uStora.Web.Models
{
    public class NotificationComponent
    {
        public void RegisterNotification(DateTime currentTime)
        {
            string conStr = ConfigurationManager.ConnectionStrings["uStoraConnection"].ConnectionString;
            #region sqlCommand
            string sqlCommand = @"SELECT  [ID],[Name],[CreatedDate]
                                FROM [dbo].[Feedbacks] 
                                where [CreatedDate] > @CreatedDate";
            #endregion
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@CreatedDate", currentTime);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                cmd.ExecuteReader();

            }
        }

        public void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Insert)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");

                RegisterNotification(DateTime.Now);
            }
        }

        public List<FeedbackViewModel> GetFeedbacks(DateTime afterDate)
        {
            using (uStoraDbContext db = new uStoraDbContext())
            {
                var feedbackVm = Mapper.Map<List<Feedback>, List<FeedbackViewModel>>(db.Feedbacks.Where(a => a.CreatedDate > afterDate && a.Status).OrderByDescending(a => a.CreatedDate).ToList());
                return feedbackVm;
            }
        }
    }
}