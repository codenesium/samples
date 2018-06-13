using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeeResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime birthDate,
                        int businessEntityID,
                        bool currentFlag,
                        string gender,
                        DateTime hireDate,
                        string jobTitle,
                        string loginID,
                        string maritalStatus,
                        DateTime modifiedDate,
                        string nationalIDNumber,
                        Nullable<short> organizationLevel,
                        Nullable<Guid> organizationNode,
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
                        this.OrganizationNode = organizationNode;
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

                public Nullable<Guid> OrganizationNode { get; private set; }

                public Guid Rowguid { get; private set; }

                public bool SalariedFlag { get; private set; }

                public short SickLeaveHours { get; private set; }

                public short VacationHours { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBirthDateValue { get; set; } = true;

                public bool ShouldSerializeBirthDate()
                {
                        return this.ShouldSerializeBirthDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCurrentFlagValue { get; set; } = true;

                public bool ShouldSerializeCurrentFlag()
                {
                        return this.ShouldSerializeCurrentFlagValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeGenderValue { get; set; } = true;

                public bool ShouldSerializeGender()
                {
                        return this.ShouldSerializeGenderValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeHireDateValue { get; set; } = true;

                public bool ShouldSerializeHireDate()
                {
                        return this.ShouldSerializeHireDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJobTitleValue { get; set; } = true;

                public bool ShouldSerializeJobTitle()
                {
                        return this.ShouldSerializeJobTitleValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLoginIDValue { get; set; } = true;

                public bool ShouldSerializeLoginID()
                {
                        return this.ShouldSerializeLoginIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMaritalStatusValue { get; set; } = true;

                public bool ShouldSerializeMaritalStatus()
                {
                        return this.ShouldSerializeMaritalStatusValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNationalIDNumberValue { get; set; } = true;

                public bool ShouldSerializeNationalIDNumber()
                {
                        return this.ShouldSerializeNationalIDNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrganizationLevelValue { get; set; } = true;

                public bool ShouldSerializeOrganizationLevel()
                {
                        return this.ShouldSerializeOrganizationLevelValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrganizationNodeValue { get; set; } = true;

                public bool ShouldSerializeOrganizationNode()
                {
                        return this.ShouldSerializeOrganizationNodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalariedFlagValue { get; set; } = true;

                public bool ShouldSerializeSalariedFlag()
                {
                        return this.ShouldSerializeSalariedFlagValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSickLeaveHoursValue { get; set; } = true;

                public bool ShouldSerializeSickLeaveHours()
                {
                        return this.ShouldSerializeSickLeaveHoursValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVacationHoursValue { get; set; } = true;

                public bool ShouldSerializeVacationHours()
                {
                        return this.ShouldSerializeVacationHoursValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBirthDateValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeCurrentFlagValue = false;
                        this.ShouldSerializeGenderValue = false;
                        this.ShouldSerializeHireDateValue = false;
                        this.ShouldSerializeJobTitleValue = false;
                        this.ShouldSerializeLoginIDValue = false;
                        this.ShouldSerializeMaritalStatusValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNationalIDNumberValue = false;
                        this.ShouldSerializeOrganizationLevelValue = false;
                        this.ShouldSerializeOrganizationNodeValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalariedFlagValue = false;
                        this.ShouldSerializeSickLeaveHoursValue = false;
                        this.ShouldSerializeVacationHoursValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>12112f215caa784e6f26df7a86c6b038</Hash>
</Codenesium>*/