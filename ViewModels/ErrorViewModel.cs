using System;

namespace LandingPage.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string AdditionalInformation { get; set; }
    }
}