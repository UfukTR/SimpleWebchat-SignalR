using SimpleWebchat.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleWebchat.Web.Models
{
    public class MessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["SimpleWebchatConnection"].ConnectionString;

        public IEnumerable<Messages> GetAllMessages()
        {
            var messages = new List<Messages>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [MessageID], [UserID], [MessageText] FROM [dbo].[Messages]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);

                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    /*
                    // Aşağıdaki kodlara alternatif ve sonucu direk return ediyor.
                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new Messages()
                            {
                                MessageID = x.GetInt32(0),
                                UserID = x.GetInt32(1),
                                MessageText = x.GetString(2)
                            }).ToList();
                    */

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: new Messages
                        {
                            MessageID = (int)reader["MessageID"],
                            UserID = (int)reader["UserID"],
                            MessageText = (string)reader["MessageText"]
                        });
                    }
                }

            }
            return messages;

        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MessagesHub.SendMessages();
            }
        }
    }
}