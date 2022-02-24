using System;
using System.Text;
using Ulaw.ApplicationProcessor.Models;
using ULaw.ApplicationProcessor.Enums;  

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        private ApplicationModel _applicationModel;
        public Application(string faculty, string courseCode, DateTime startdate, string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa)
        {
            _applicationModel = new ApplicationModel
            {
                ApplicationId = new Guid(),
                Faculty = faculty,
                CourseCode = courseCode,
                StartDate = startdate,
                Title = title,
                FirstName = firstName,
                LastName = lastName,
                RequiresVisa = requiresVisa,
                DateOfBirth = dateOfBirth
            };
        }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }

        public string Process()
        {
            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");

            if (DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                result.Append(string.Format("<p> Dear {0}, </p>", _applicationModel.FirstName));
                result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", _applicationModel.CourseCode, _applicationModel.StartDate.ToLongDateString()));
                result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                result.Append("<br/> Yours sincerely,");
                result.Append("<p/> The Admissions Team,");
            }
            else
            {
                if (DegreeGrade == DegreeGradeEnum.third)
                {
                    result.Append(string.Format("<p> Dear {0}, </p>", _applicationModel.FirstName));
                    result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
                    result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                    result.Append("<br> Yours sincerely,");
                    result.Append("<p/> The Admissions Team,");
                }
                else
                {
                    if (DegreeSubject == DegreeSubjectEnum.law || DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
                    {
                        decimal depositAmount = 350.00M;

                        result.Append(string.Format("<p> Dear {0}, </p>", _applicationModel.FirstName));
                        result.Append(string.Format("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", _applicationModel.CourseCode, _applicationModel.StartDate.ToLongDateString()));
                        result.Append(string.Format("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", DegreeSubject.ToDescription(), DegreeGrade.ToDescription()));
                        result.Append(string.Format("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString()));
                        result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));
                        result.Append(string.Format("<br/> Yours sincerely,"));
                        result.Append(string.Format("<p/> The Admissions Team,"));
                    }
                    else
                    {
                        result.Append(string.Format("<p> Dear {0}, </p>", _applicationModel.FirstName));
                        result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", _applicationModel.CourseCode, _applicationModel.StartDate.ToLongDateString()));
                        result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                        result.Append("<br/> Yours sincerely,");
                        result.Append("<p/> The Admissions Team,");
                    }
                }
            }

             result.Append(string.Format("</body></html>"));

            return result.ToString();
        }

    }
}

