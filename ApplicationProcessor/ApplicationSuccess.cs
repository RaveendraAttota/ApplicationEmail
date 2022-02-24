using System;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;

namespace Ulaw.ApplicationProcessor
{
    //Created classes based on application status type so in future if any methods need to be introduced to only this status, this can be done without modifying other classes
    public class ApplicationSuccess : IApplicationEmail
    {
        public string GetEmailText(string firstName, string courseCode = null, DateTime? startDate = null, string degreeSubject = null, string degreeGrade = null, decimal? depositAmount = null)
        {
            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");
            result.Append(string.Format("<p> Dear {0}, </p>", firstName));
            result.Append(string.Format("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", courseCode, startDate?.ToLongDateString()));
            result.Append(string.Format("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", degreeSubject, degreeGrade));
            result.Append(string.Format("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString()));
            result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            return result.Append(string.Format("</body></html>")).ToString();
        }
    }
}
