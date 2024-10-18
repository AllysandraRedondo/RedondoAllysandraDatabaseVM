using MODELSdb;
using DATALAYERdb;
using MailKit.Net.Smtp;
using MimeKit;

namespace BUSINESSLOGICdb
{
    public class AnimeProcess
    {
        SqlData data = new SqlData();

        public List<AnimeContent> GetAllAnime()
        {
            return data.GetAnime();
        }

        public int AddAnime(AnimeContent anime)
        {
            int result = data.AddAnime(anime.title, anime.studio, anime.releasedate, anime.status, anime.genre, anime.episodes, anime.summary);

            if (result == 1)
            {
                SendEmailNotification(anime, " A New Anime Added", "A New Anime has been Successfully Added.");
            }

            return result;
        }

        public int RemoveAnime(string title)
        {
            int result = data.RemoveAnime(title); 

            if (result == 1)
            {
                SendEmailNotification(new MODELSdb.AnimeContent { title = title }, "Selected Anime Deleted", "The Selected Anime has been Successfully Deleted.");
            }

            return result;
        }

        public int UpdateAnime(AnimeContent AnyInfo)
        {
            int result = data.UpdateAAnime(AnyInfo.title, AnyInfo.studio, AnyInfo.releasedate, AnyInfo.status, AnyInfo.genre, AnyInfo.episodes, AnyInfo.summary);

            if (result == 1)
            {
                SendEmailNotification(AnyInfo, " Selected Anime Updated", "Your anime has been successfully updated.");
            }

            return result;
        }

        
        public void SendEmailNotification(AnimeContent anime, string subject, string bodyMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("AnimeApp", "redondoallysandra11@gmail.com"));
            message.To.Add(new MailboxAddress("User", "redondoally02@gmail.com"));
            message.Subject = subject;

             message.Body = new TextPart("html")
            {
                Text = $"<h1>{anime.title} {subject}</h1>" +
               $"<p>Anime Title: {anime.title}</p>" +
               $"<p>Studio: {anime.studio}</p>" +
               $"<p>Release Date: {anime.releasedate}</p>" +
               $"<p>Status: {anime.status}</p>" +
               $"<p>Genre: {anime.genre}</p>" +
               $"<p>Episodes: {anime.episodes}</p>" +
               $"<p>Summary: {anime.summary}</p>"
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
