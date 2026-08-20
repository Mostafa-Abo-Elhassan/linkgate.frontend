namespace LinkGate.Web.Models.Applications.Responses
{
    public class ApplicationSubmitResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class ImageUploadResponse
    {
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class BusinessErrorResponse
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
    }
}