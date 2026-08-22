namespace LinkGate.frontend.Models.Applications.Requests
{
    public sealed class ViewApplicationsRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Status { get; set; } // لإرساله في الفلتر لو الـ API بتدعمه
    }
}