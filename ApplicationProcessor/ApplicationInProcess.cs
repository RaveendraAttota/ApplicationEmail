using System;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;

namespace Ulaw.ApplicationProcessor
{
    //Created classes based on application status type so in future if any methods need to be introduced to only this status, this can be done without modifying other classes
    public class ApplicationInProcess : IApplicationEmail
    {
        public string GetEmailText(string firstName, string courseCode = null, DateTime? startDate = null, string degreeSubject = null, string degreeGrade = null, decimal? depositAmount = null)
        {
            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");
            result.Append(string.Format("<p> Dear {0}, </p>", firstName));
            result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", courseCode, startDate?.ToLongDateString()));
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            return result.Append(string.Format("</body></html>")).ToString();
        }
    }
}
