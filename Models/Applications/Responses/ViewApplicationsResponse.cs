using System;
using System.Collections.Generic;

namespace LinkGate.frontend.Models.Applications.Responses
{
    public sealed class ViewApplicationsResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<ApplicationListItemResponse> Applications { get; set; } = new();
    }

    public sealed class ApplicationListItemResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LinkedInProfileUrl { get; set; } = string.Empty;
        public int NumberOfConnections { get; set; }
        public string NumberOfConnectionsScreenshotUrl { get; set; } = string.Empty;
        public DateOnly LinkedInAccountCreationDate { get; set; }
        public string AccountCreationDateScreenshotUrl { get; set; } = string.Empty;
        public bool AcceptTermsAndPolicies { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? RejectionReason { get; set; }
    }

    public sealed class ApplicationsAnalyticsResponse
    {
        public int PendingApplications { get; set; }
        public int ApprovedApplications { get; set; }
        public int RejectedApplications { get; set; }

        // خاصية إضافية للفرونت اند لحساب الإجمالي بسهولة
        public int TotalAccounts => PendingApplications + ApprovedApplications + RejectedApplications;
    }
}