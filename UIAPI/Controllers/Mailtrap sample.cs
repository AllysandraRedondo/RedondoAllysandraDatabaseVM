using MailKit.Net.Smtp;
using MimeKit;

namespace new_email_tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromMyNotes", "do-not-reply@frommynotes.com"));
            message.To.Add(new MailboxAddress("User", "user@example.com")); // Change to recipient email
            message.Subject = "Thanks for Subscribing!"; // Customize subject

            // Customize email body
            message.Body = new TextPart("html")
            {
                Text = "<h1>Hi, User!</h1>" +
                "<p>Thank you for subscribing to frommynotes newsletter.</p>" +
                "<p><strong>Welcome!</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Connect to Mailtrap's sandbox SMTP server
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    // Replace with your Mailtrap SMTP username and password
                    client.Authenticate("your_mailtrap_username", "your_mailtrap_password");

                    // Send email
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
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
