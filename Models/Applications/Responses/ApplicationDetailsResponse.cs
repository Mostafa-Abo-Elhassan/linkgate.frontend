using System;

namespace LinkGate.frontend.Models.Applications.Responses
{
    public sealed class ApplicationDetailsResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LinkedInUrl { get; set; } = string.Empty;
        public int NumberOfConnections { get; set; }
        public string NumberOfConnectionsScreenshotUrl { get; set; } = string.Empty;
        public DateOnly LinkedInAccountCreationDate { get; set; }
        public string AccountCreationDateScreenshotUrl { get; set; } = string.Empty;
        public int? AccountAgeYears { get; set; }
        public int? AccountAgeMonths { get; set; }
        public bool AcceptTermsAndPolicies { get; set; }
        // 0 = Pending, 1 = Approved, 2 = Rejected (حسب الـ JSON راجعة كرقم)
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? AdminNote { get; set; }
        public string? Notes { get; set; }
        public string? ReferralCode { get; set; }
        public Guid? ReviewedByAdminId { get; set; }

        // Helper لعرض اسم الحالة بالانجليزي
        // Helper لعرض اسم الحالة بالانجليزي
        public string StatusName => Status switch
        {
            2 => "Approved",
            3 => "Rejected",
            _ => "Pending" // 1 = Pending
        };
    }

    public sealed class ApproveApplicationResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool EmailSent { get; set; }
    }

    public sealed class RejectApplicationResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Reason { get; set; }
        public bool EmailSent { get; set; }
    }
}