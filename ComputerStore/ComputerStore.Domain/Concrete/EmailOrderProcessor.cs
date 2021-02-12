﻿
using System.Text;
using System.Net;
using System.Net.Mail;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
   
        public class EmailSettings
        {
            public string MailToAddress = "orders@example.com";
            public string MailFromAddress = "computerstore@example.com";
            public bool UseSsl = true;
            public string Username = "MySmtpUsername";
            public string Password = "MySmtpPassword";
            public string ServerName = "smtp.example.com";
            public int ServerPort = 587;
            public bool WriteAsFile = true;
            public string FileLocation = @"c:\computer_store_emails";
        }

        public class EmailOrderProcessor : IOrderProcessor
        {
            private EmailSettings emailSettings;

            public EmailOrderProcessor(EmailSettings settings)
            {
                emailSettings = settings;
            }

            public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = emailSettings.UseSsl;
                    smtpClient.Host = emailSettings.ServerName;
                    smtpClient.Port = emailSettings.ServerPort;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials
                        = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                    if (emailSettings.WriteAsFile)
                    {
                        smtpClient.DeliveryMethod
                            = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                        smtpClient.EnableSsl = false;
                    }

                    StringBuilder body = new StringBuilder()
                        .AppendLine("New order processed")
                        .AppendLine("---")
                        .AppendLine("Goods:");

                    foreach (var line in cart.Lines)
                    {
                        var subtotal = line.ComputerComponent.Price * line.Quantity;
                        body.AppendFormat("{0} x {1} (Total: {2:c}",
                            line.Quantity, line.ComputerComponent.Name, subtotal);
                    }

                    body.AppendFormat("Total cost: {0:c}", cart.ComputeTotalValue())
                        .AppendLine("---")
                        .AppendLine("Delivery:")
                        .AppendLine(shippingInfo.Name)
                        .AppendLine(shippingInfo.Line1)
                        .AppendLine(shippingInfo.Line2 ?? "")
                        .AppendLine(shippingInfo.Line3 ?? "")
                        .AppendLine(shippingInfo.City)
                        .AppendLine(shippingInfo.Country)
                        .AppendLine("---")
                        .AppendFormat("Gift wrapping: {0}",
                            shippingInfo.GiftWrap ? "Yes" : "No");

                    MailMessage mailMessage = new MailMessage(
                                           emailSettings.MailFromAddress,   // From
                                           emailSettings.MailToAddress,     // To
                                           "New order shipped!",        // Title
                                           body.ToString());                // Letter body

                    if (emailSettings.WriteAsFile)
                    {
                        mailMessage.BodyEncoding = Encoding.UTF8;
                    }

                    smtpClient.Send(mailMessage);
                }
            }
        }
    
}
