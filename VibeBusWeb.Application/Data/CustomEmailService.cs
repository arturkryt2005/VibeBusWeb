using System.Net;
using System.Net.Mail;

namespace VibeBusWeb.Application.Data
{
    public interface IEmailService
    {
        Task<CustomErrorMessage> SendMessage(string selectedCity, DateTime departureDate);
    }

    public class CustomEmailService : IEmailService
    {
        private readonly UserService _userService;

        public CustomEmailService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<CustomErrorMessage> SendMessage(string selectedCityName, DateTime departureDate)
        {
            const string urlBackground = "https://photogora.ru/img/product/thumb/4947/5d2ef838a9cc69778828569119077791.jpg";
            const string urlLogo = "https://326605.selcdn.ru/03005/iblock/340/logotip-KAI.jpg";
            var formattedDepartureDate = departureDate.Date;

            try
            {
                var smtp = new SmtpClient("smtp.mail.ru", 587)
                {
                    Credentials = new NetworkCredential("studencheskiy.sovet.kit@mail.ru", "jUprRdgq75S5dYasZik4"),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress("studencheskiy.sovet.kit@mail.ru")
                };

                mail.To.Add(_userService.CurrentUser.Email);
                mail.Subject = "Подтверждение бронирования тура";
                mail.Body =
                    $@"<!DOCTYPE html>
            <html>
            <head>
                <title>Подтверждение бронирования тура</title>
            </head>
            <body style=""font-family: Montserrat, sans-serif; font-size: 16px; line-height: 1.5; color: #333; background-color: #f5f5f5;"">
                <div style=""max-width: 600px; margin: 0 auto; padding: 20px; background-color: #fff; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); background-image: url({urlBackground}); background-size: cover;"">
                    <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px; text-align: center; color: black;"">Подтверждение бронирования тура</h1>
                    <div style=""background-color: #fff; border: 1px solid #ccc; border-radius: 5px; padding: 20px; margin-bottom: 20px;"">
                        <div style=""display: flex; align-items: center; justify-content: space-between; margin-bottom: 20px;"">
                            <div style=""width: 100px; height: 100px; background-color: #ccc; border-radius: 50%; margin-right: 20px; background-image: url({urlLogo}); background-position: center; background-size: contain; background-size: cover;""></div>
                            <h1 style=""font-family: Montserrat Black; padding-top: 10px; font-size: 40px; color: #333;"">Подтверждение бронирования тура</h1>
                        </div>
                        <div style=""display: flex; flex-direction: column; margin-bottom: 20px;"">
                            <div style=""display: flex; align-items: center; margin-bottom: 10px;"">
                                <span style=""font-weight: bold; margin-right: 10px; color: #333;"">Город отправления:</span>
                                <span style=""margin: 0; color: #666;"">{selectedCityName}<br /></span>
                            </div>
                            <div style=""display: flex; align-items: center; margin-bottom: 10px;"">
                                <span style=""font-weight: bold; margin-right: 10px; color: #333;"">Дата выезда:</span>
                                <span style=""margin: 0; color: #666;"">{departureDate}<br /></span>
                            </div>
                        </div>
                    </div>
                </div>
            </body>
            </html>";
                mail.IsBodyHtml = true;

                await smtp.SendMailAsync(mail);

                return new CustomErrorMessage
                {
                    ErrorMessage = $"Письмо успешно отправлено.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new CustomErrorMessage
                {
                    ErrorMessage = ex.Message,
                    Success = false
                };
            }
        }

    }
}
