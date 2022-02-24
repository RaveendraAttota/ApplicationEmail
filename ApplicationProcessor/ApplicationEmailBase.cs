using System;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;

namespace Ulaw.ApplicationProcessor
{
    //Thought of introducing abstract base class so that any common methods can go here
    public abstract class ApplicationEmailBase : IApplicationEmail
    {
        public abstract string GetEmailText(string firstName, string courseCode = null, DateTime? startDate = null, string degreeSubject = null, string degreeGrade = null, decimal? depositAmount = null);

        public StringBuilder GetHeader(string firstName)
        {
            var header = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");
            return header.Append(string.Format("<p> Dear {0}, </p>", firstName));
        }
        public string GetFooter()
        {
            return "<p/> The Admissions Team,</body></html>";
        }
    }
}
