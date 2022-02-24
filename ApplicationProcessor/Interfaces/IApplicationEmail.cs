using System;

namespace Ulaw.ApplicationProcessor.Interfaces
{
    //Thought about creating three separte interfaces for each applcation status type but then all would have the same method repeated.
    //So going with a method with optional parameters
    public interface IApplicationEmail
    {
        string GetEmailText(string firstName, string courseCode = null, DateTime? startDate = null, string degreeSubject = null, string degreeGrade = null, decimal? depositAmount = null);
    }
}
