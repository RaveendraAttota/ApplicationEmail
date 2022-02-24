using System;

namespace Ulaw.ApplicationProcessor
{
    //Created classes based on application status type so in future if any methods need to be introduced to only this status, this can be done without modifying other classes
    public class ApplicationInProcess : ApplicationEmailBase
    {
        public override string GetEmailText(string firstName, string courseCode = null, DateTime? startDate = null, string degreeSubject = null, string degreeGrade = null, decimal? depositAmount = null)
        {
            var result = GetHeader(firstName);
            result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", courseCode, startDate?.ToLongDateString()));
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            return result.Append(GetFooter()).ToString();
        }
    }
}
