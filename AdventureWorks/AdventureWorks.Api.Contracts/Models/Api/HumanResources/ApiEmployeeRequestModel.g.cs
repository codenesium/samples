using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmployeeRequestModel : AbstractApiRequestModel
        {
                public ApiEmployeeRequestModel()
                        : base()
                {
                }

                public void SetProperties(
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

                private DateTime birthDate;

                [Required]
                public DateTime BirthDate
                {
                        get
                        {
                                return this.birthDate;
                        }

                        set
                        {
                                this.birthDate = value;
                        }
                }

                private bool currentFlag;

                [Required]
                public bool CurrentFlag
                {
                        get
                        {
                                return this.currentFlag;
                        }

                        set
                        {
                                this.currentFlag = value;
                        }
                }

                private string gender;

                [Required]
                public string Gender
                {
                        get
                        {
                                return this.gender;
                        }

                        set
                        {
                                this.gender = value;
                        }
                }

                private DateTime hireDate;

                [Required]
                public DateTime HireDate
                {
                        get
                        {
                                return this.hireDate;
                        }

                        set
                        {
                                this.hireDate = value;
                        }
                }

                private string jobTitle;

                [Required]
                public string JobTitle
                {
                        get
                        {
                                return this.jobTitle;
                        }

                        set
                        {
                                this.jobTitle = value;
                        }
                }

                private string loginID;

                [Required]
                public string LoginID
                {
                        get
                        {
                                return this.loginID;
                        }

                        set
                        {
                                this.loginID = value;
                        }
                }

                private string maritalStatus;

                [Required]
                public string MaritalStatus
                {
                        get
                        {
                                return this.maritalStatus;
                        }

                        set
                        {
                                this.maritalStatus = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string nationalIDNumber;

                [Required]
                public string NationalIDNumber
                {
                        get
                        {
                                return this.nationalIDNumber;
                        }

                        set
                        {
                                this.nationalIDNumber = value;
                        }
                }

                private Nullable<short> organizationLevel;

                public Nullable<short> OrganizationLevel
                {
                        get
                        {
                                return this.organizationLevel.IsEmptyOrZeroOrNull() ? null : this.organizationLevel;
                        }

                        set
                        {
                                this.organizationLevel = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private bool salariedFlag;

                [Required]
                public bool SalariedFlag
                {
                        get
                        {
                                return this.salariedFlag;
                        }

                        set
                        {
                                this.salariedFlag = value;
                        }
                }

                private short sickLeaveHours;

                [Required]
                public short SickLeaveHours
                {
                        get
                        {
                                return this.sickLeaveHours;
                        }

                        set
                        {
                                this.sickLeaveHours = value;
                        }
                }

                private short vacationHours;

                [Required]
                public short VacationHours
                {
                        get
                        {
                                return this.vacationHours;
                        }

                        set
                        {
                                this.vacationHours = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>ddcfaf0e2209bb8acfe2e13ff18466e4</Hash>
</Codenesium>*/