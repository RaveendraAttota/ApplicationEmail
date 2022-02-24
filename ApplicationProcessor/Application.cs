using System;
using Ulaw.ApplicationProcessor;
using Ulaw.ApplicationProcessor.Interfaces;
using Ulaw.ApplicationProcessor.Models;
using ULaw.ApplicationProcessor.Enums;

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        private ApplicationModel _applicationModel;

        //Choosing property injection as with constructor or method injection, unit tests need to be modified-avoiding that
        private IApplicationEmail _applicationEmail;
        public IApplicationEmail ApplicationEmail
        {
            set
            {
                _applicationEmail = value;
            }
            get
            {
                if (ApplicationEmail == null)
                {
                    throw new Exception("ApplicationEmail is not initialized");
                }
                else
                {
                    return _applicationEmail;
                }
            }
        }

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
            //Nested if loops are always bad so cleaning up
            if (DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                ApplicationEmail = new ApplicationInProcess();
                return _applicationEmail.GetEmailText(_applicationModel.FirstName, _applicationModel.CourseCode, _applicationModel.StartDate);
            }

            if (DegreeGrade == DegreeGradeEnum.third)
            {
                ApplicationEmail = new ApplicationRefusal();
                return _applicationEmail.GetEmailText(_applicationModel.FirstName);
            }

            if (DegreeSubject == DegreeSubjectEnum.law || DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
            {
                ApplicationEmail = new ApplicationSuccess();
                return _applicationEmail.GetEmailText(_applicationModel.FirstName, _applicationModel.CourseCode, _applicationModel.StartDate, DegreeSubject.ToDescription(), DegreeGrade.ToDescription(), 350.00M);
            }

            ApplicationEmail = new ApplicationInProcess();
            return _applicationEmail.GetEmailText(_applicationModel.FirstName, _applicationModel.CourseCode, _applicationModel.StartDate);
        }

    }
}

