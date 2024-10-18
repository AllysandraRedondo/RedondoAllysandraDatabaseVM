using DATALAYERdb;
using MODELSdb;
using MailKit.Net.Smtp;
using MimeKit;


namespace BUSINESSLOGICdb
{
    public class VerifyingUser
    {

        OwnerData data = new OwnerData();

        public List<OwnerContent> GetAllUsers()
        {
            return data.GetUsers();
        }

        public int AddUser(OwnerContent user)
        {
            int result = data.AddnewUser(user.username, user.password);

            if (result == 1)
            {
                SendEmailNotification(user, " A New User Added", "A New User has been Successfully Added.");
            }

            return result;
        }

        public int RemoveUser(string user)
        {
            int result = data.RemoveUser(user);

            if (result == 1)
            {
                SendEmailNotification(new MODELSdb.OwnerContent { username = user }, "Selected User Deleted", "The Selected User has been Successfully Deleted.");
            }

            return result;
        }

        public int UpdateUser(OwnerContent AnyInfo)
        {
            int result = data.UpdateAUser(AnyInfo.username, AnyInfo.password);

            if (result == 1)
            {
                SendEmailNotification(AnyInfo, " Selected Anime Updated", "Your anime has been successfully updated.");
            }

            return result;
        }


        public void SendEmailNotification(OwnerContent users, string subject, string bodyMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("AnimeApp", "redondoallysandra11@gmail.com"));
            message.To.Add(new MailboxAddress("User", "redondoally02@gmail.com"));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = $"<h1>{users.username} {subject}</h1>" +
              $"<p>Anime Title: {users.username}</p>" +
              $"<p>Studio: {users.password}</p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("0906280e052fbd", "91b3d6957ea54e");
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }

        }
    }
}
