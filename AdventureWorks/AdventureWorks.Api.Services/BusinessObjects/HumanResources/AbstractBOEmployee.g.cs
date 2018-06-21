using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOEmployee : AbstractBusinessObject
        {
                public AbstractBOEmployee()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  DateTime birthDate,
                                                  bool currentFlag,
                                                  string gender,
                                                  DateTime hireDate,
                                                  string jobTitle,
                                                  string loginID,
                                                  string maritalStatus,
                                                  DateTime modifiedDate,
                                                  string nationalIDNumber,
                                                  Nullable<short> organizationLevel,
                                                  Guid rowguid,
                                                  bool salariedFlag,
                                                  short sickLeaveHours,
                                                  short vacationHours)
                {
                        this.BirthDate = birthDate;
                        this.BusinessEntityID = businessEntityID;
                        this.CurrentFlag = currentFlag;
                        this.Gender = gender;
                        this.HireDate = hireDate;
                        this.JobTitle = jobTitle;
                        this.LoginID = loginID;
                        this.MaritalStatus = maritalStatus;
                        this.ModifiedDate = modifiedDate;
                        this.NationalIDNumber = nationalIDNumber;
                        this.OrganizationLevel = organizationLevel;
                        this.Rowguid = rowguid;
                        this.SalariedFlag = salariedFlag;
                        this.SickLeaveHours = sickLeaveHours;
                        this.VacationHours = vacationHours;
                }

                public DateTime BirthDate { get; private set; }

                public int BusinessEntityID { get; private set; }

                public bool CurrentFlag { get; private set; }

                public string Gender { get; private set; }

                public DateTime HireDate { get; private set; }

                public string JobTitle { get; private set; }

                public string LoginID { get; private set; }

                public string MaritalStatus { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string NationalIDNumber { get; private set; }

                public Nullable<short> OrganizationLevel { get; private set; }

                public Guid Rowguid { get; private set; }

                public bool SalariedFlag { get; private set; }

                public short SickLeaveHours { get; private set; }

                public short VacationHours { get; private set; }
        }
}

/*<Codenesium>
    <Hash>be1b7e6860741511bf426e91829e0fc8</Hash>
</Codenesium>*/