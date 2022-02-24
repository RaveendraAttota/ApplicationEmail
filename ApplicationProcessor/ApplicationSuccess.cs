using System;

namespace Ulaw.ApplicationProcessor
{
    //Created classes based on application status type so in future if any methods need to be introduced to only this status, this can be done without modifying other classes
    public class ApplicationSuccess : ApplicationEmailBase
    {
        public override string GetEmailText(string firstName, string courseCode, DateTime? startDate, string degreeSubject, string degreeGrade, decimal? depositAmount)
        {
            var result = GetHeader(firstName);
            result.Append(string.Format("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", courseCode, startDate?.ToLongDateString()));
            result.Append(string.Format("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", degreeSubject, degreeGrade));
            result.Append(string.Format("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString()));
            result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));
            result.Append(string.Format("<br/> Yours sincerely,"));
            return result.Append(GetFooter()).ToString();
        }
    }
}
