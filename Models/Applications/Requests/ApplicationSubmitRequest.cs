using System.ComponentModel.DataAnnotations;

namespace LinkGate.frontend.Models.Applications.Requests
{
    // Models/Applications/Requests/ApplicationSubmitRequest.cs
    //public class ApplicationSubmitRequest
    //{
    //    public string FullName { get; set; } = string.Empty;
    //    public string PhoneNumber { get; set; } = string.Empty;
    //    public string Email { get; set; } = string.Empty;
    //    public string LinkedInProfileUrl { get; set; } = string.Empty;
    //    public int NumberOfConnections { get; set; }
    //    public DateOnly LinkedInAccountCreationDate { get; set; }
    //    public string Notes { get; set; } = string.Empty;
    //    public bool AcceptTermsAndPolicies { get; set; }

    //    // عدل الأسماء هنا لتطابق الـ Backend تماماً 👇
    //    public string NumberOfConnectionsScreenshotUrl { get; set; } = string.Empty;
    //    public string AccountCreationDateScreenshotUrl { get; set; } = string.Empty;
    //}

    public class ApplicationSubmitRequest
    {
        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "رقم الهاتف يجب أن يكون رقم مصري صحيح يتكون من 11 رقم (يبدأ بـ 010, 011, 012, أو 015)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "رابط حساب لينكد إن مطلوب")]
        [RegularExpression(@"^(https?:\/\/)?(www\.)?linkedin\.com\/.*$", ErrorMessage = "يجدر إدخال رابط لينكد إن صحيح (يبدأ بـ linkedin.com)")]
        public string LinkedInProfileUrl { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "عدد الـ Connections يجب أن يكون أكبر من صفر")]
        public int NumberOfConnections { get; set; }

        [Required(ErrorMessage = "تاريخ إنشاء الحساب مطلوب")]
        public DateOnly LinkedInAccountCreationDate { get; set; }

        public string Notes { get; set; } = string.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "يجب الموافقة على الشروط والسياسات")]
        public bool AcceptTermsAndPolicies { get; set; }

        [Required(ErrorMessage = "صورة عدد الـ Connections مطلوبة")]
        public string NumberOfConnectionsScreenshotUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "صورة تاريخ إنشاء الحساب مطلوبة")]
        public string AccountCreationDateScreenshotUrl { get; set; } = string.Empty;
    }
}
