using LinkGate.frontend.Models.Applications.Requests;
using LinkGate.frontend.Models.Applications.Responses;
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

        // This method submits an application to the backend API and returns a tuple indicating success, a message, and the response data if successful.
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



        //UploadImageAsync
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



        // This method retrieves a paginated list of applications from the backend API, optionally filtered by status.
        public async Task<ViewApplicationsResponse?> GetApplicationsAsync(int page = 1, int pageSize = 10)
        {
            var query = $"api/v1/admin/applications?Page={page}&PageSize={pageSize}";
            return await _http.GetFromJsonAsync<ViewApplicationsResponse>(query);
        }



        // This method retrieves analytics data about applications from the backend API.
        public async Task<ApplicationsAnalyticsResponse?> GetAnalyticsAsync()
        {
            return await _http.GetFromJsonAsync<ApplicationsAnalyticsResponse>("api/v1/admin/applications/analytics");
        }


        // This method retrieves detailed information about a specific application by its ID from the backend API.
        public async Task<ApplicationDetailsResponse?> GetApplicationDetailsAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<ApplicationDetailsResponse>($"/api/v1/admin/applications/{id}");
        }

        public async Task<ApproveApplicationResponse?> ApproveApplicationAsync(Guid id)
        {
            var response = await _http.PutAsync($"/api/v1/admin/applications/{id}/approve", null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApproveApplicationResponse>();
            }
            return null;
        }

        public async Task<RejectApplicationResponse?> RejectApplicationAsync(Guid id, string? reason)
        {
            var request = new RejectApplicationRequest { Reason = reason };
            var response = await _http.PutAsJsonAsync($"/api/v1/admin/applications/{id}/reject", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RejectApplicationResponse>();
            }
            return null;
        }

    }
}