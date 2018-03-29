using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployee
	{
		public POCOEmployee()
		{}

		public POCOEmployee(int businessEntityID,
		                    string nationalIDNumber,
		                    string loginID,
		                    Nullable<Guid> organizationNode,
		                    Nullable<short> organizationLevel,
		                    string jobTitle,
		                    DateTime birthDate,
		                    string maritalStatus,
		                    string gender,
		                    DateTime hireDate,
		                    bool salariedFlag,
		                    short vacationHours,
		                    short sickLeaveHours,
		                    bool currentFlag,
		                    Guid rowguid,
		                    DateTime modifiedDate)
		{
			this.NationalIDNumber = nationalIDNumber;
			this.LoginID = loginID;
			this.OrganizationNode = organizationNode;
			this.OrganizationLevel = organizationLevel;
			this.JobTitle = jobTitle;
			this.BirthDate = birthDate;
			this.MaritalStatus = maritalStatus;
			this.Gender = gender;
			this.HireDate = hireDate;
			this.SalariedFlag = salariedFlag;
			this.VacationHours = vacationHours;
			this.SickLeaveHours = sickLeaveHours;
			this.CurrentFlag = currentFlag;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Person");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public string NationalIDNumber {get; set;}
		public string LoginID {get; set;}
		public Nullable<Guid> OrganizationNode {get; set;}
		public Nullable<short> OrganizationLevel {get; set;}
		public string JobTitle {get; set;}
		public DateTime BirthDate {get; set;}
		public string MaritalStatus {get; set;}
		public string Gender {get; set;}
		public DateTime HireDate {get; set;}
		public bool SalariedFlag {get; set;}
		public short VacationHours {get; set;}
		public short SickLeaveHours {get; set;}
		public bool CurrentFlag {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNationalIDNumberValue {get; set;} = true;

		public bool ShouldSerializeNationalIDNumber()
		{
			return ShouldSerializeNationalIDNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLoginIDValue {get; set;} = true;

		public bool ShouldSerializeLoginID()
		{
			return ShouldSerializeLoginIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationNodeValue {get; set;} = true;

		public bool ShouldSerializeOrganizationNode()
		{
			return ShouldSerializeOrganizationNodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationLevelValue {get; set;} = true;

		public bool ShouldSerializeOrganizationLevel()
		{
			return ShouldSerializeOrganizationLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeJobTitleValue {get; set;} = true;

		public bool ShouldSerializeJobTitle()
		{
			return ShouldSerializeJobTitleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBirthDateValue {get; set;} = true;

		public bool ShouldSerializeBirthDate()
		{
			return ShouldSerializeBirthDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaritalStatusValue {get; set;} = true;

		public bool ShouldSerializeMaritalStatus()
		{
			return ShouldSerializeMaritalStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGenderValue {get; set;} = true;

		public bool ShouldSerializeGender()
		{
			return ShouldSerializeGenderValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeHireDateValue {get; set;} = true;

		public bool ShouldSerializeHireDate()
		{
			return ShouldSerializeHireDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalariedFlagValue {get; set;} = true;

		public bool ShouldSerializeSalariedFlag()
		{
			return ShouldSerializeSalariedFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVacationHoursValue {get; set;} = true;

		public bool ShouldSerializeVacationHours()
		{
			return ShouldSerializeVacationHoursValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSickLeaveHoursValue {get; set;} = true;

		public bool ShouldSerializeSickLeaveHours()
		{
			return ShouldSerializeSickLeaveHoursValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrentFlagValue {get; set;} = true;

		public bool ShouldSerializeCurrentFlag()
		{
			return ShouldSerializeCurrentFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeNationalIDNumberValue = false;
			this.ShouldSerializeLoginIDValue = false;
			this.ShouldSerializeOrganizationNodeValue = false;
			this.ShouldSerializeOrganizationLevelValue = false;
			this.ShouldSerializeJobTitleValue = false;
			this.ShouldSerializeBirthDateValue = false;
			this.ShouldSerializeMaritalStatusValue = false;
			this.ShouldSerializeGenderValue = false;
			this.ShouldSerializeHireDateValue = false;
			this.ShouldSerializeSalariedFlagValue = false;
			this.ShouldSerializeVacationHoursValue = false;
			this.ShouldSerializeSickLeaveHoursValue = false;
			this.ShouldSerializeCurrentFlagValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fd80d4304372ba20cafddbb213ab5930</Hash>
</Codenesium>*/