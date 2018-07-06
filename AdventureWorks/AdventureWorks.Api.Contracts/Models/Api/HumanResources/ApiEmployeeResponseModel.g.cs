using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmployeeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime birthDate,
                        bool currentFlag,
                        string gender,
                        DateTime hireDate,
                        string jobTitle,
                        string loginID,
                        string maritalStatus,
                        DateTime modifiedDate,
                        string nationalIDNumber,
                        short? organizationLevel,
                        Guid rowguid,
                        bool salariedFlag,
                        short sickLeaveHours,
                        short vacationHours)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.BirthDate = birthDate;
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

                public short? OrganizationLevel { get; private set; }

                public Guid Rowguid { get; private set; }

                public bool SalariedFlag { get; private set; }

                public short SickLeaveHours { get; private set; }

                public short VacationHours { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5f51a5b308fc91b2a00ed05ebe7ce7d0</Hash>
</Codenesium>*/