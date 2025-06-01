using PetCareApplication.Domain.Entities.User;
using System.Net.Http.Json;

namespace PetCareApplication.Infrastructure.Services
{
    public interface IEmailNotifierService
    {
        Task SendUserRegisteredEmail(UserEntity user);
    }

    public class EmailNotifierService(HttpClient httpClient) : IEmailNotifierService
    {
        public async Task SendUserRegisteredEmail(UserEntity user)
        {
            var command = new
            {
                Title = "Rejestracja w PetCare",
                SenderName = "PetCare",
                SenderSurname = "",
                TelephoneNumber = "111222333",
                SenderEmail = "animalscarecompany@gmail.com",
                ReceiverEmail = user.Email,
                Message = $"Cześć {user.UserName},\n\n" +

                $"Dziękujemy za rejestrację w PetCare!"
            };

            var response = await httpClient.PostAsJsonAsync("http://localhost:5002/emails/sendGmail", command);

            if (!response.IsSuccessStatusCode)
                await response.Content.ReadAsStringAsync();
        }
    }
}
