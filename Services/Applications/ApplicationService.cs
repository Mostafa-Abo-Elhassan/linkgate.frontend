using LinkGate.frontend.Models.Applications.Requests;
using LinkGate.Web.Models.Applications.Responses;
using System.Net.Http.Json;

namespace LinkGate.frontend.Services.Applications
{
    public class ApplicationService
    {
        private readonly HttpClient _http;

        public ApplicationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<(bool IsSuccess, string Message, ApplicationSubmitResponse? Data)> SubmitApplicationAsync(ApplicationSubmitRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/v1/public/applications", request);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<ApplicationSubmitResponse>();
                    return (true, "Application submitted successfully.", data);
                }

                if ((int)response.StatusCode == 409)
                {
                    var error = await response.Content.ReadFromJsonAsync<BusinessErrorResponse>();
                    return (false, error?.Detail ?? "انت بالفعل عملت Application.", null);
                }

                return (false, "حدث خطأ غير متوقع أثناء إرسال الطلب.", null);
            }
            catch (Exception)
            {
                return (false, "تعذر الاتصال بالخادم. تأكد من اتصال الإنترنت.", null);
            }
        }

        public async Task<string> UploadImageAsync(MultipartFormDataContent content)
        {
            var response = await _http.PostAsync("api/v1/public/images/upload", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ImageUploadResponse>();
                return result?.ImageUrl ?? string.Empty;
            }

            throw new Exception("فشل رفع الصورة إلى السيرفر.");
        }
    }
}