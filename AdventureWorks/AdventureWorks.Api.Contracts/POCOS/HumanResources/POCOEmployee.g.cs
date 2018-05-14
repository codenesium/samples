using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployee
	{
		public POCOEmployee()
		{}

		public POCOEmployee(
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
			this.BirthDate = birthDate.ToDateTime();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CurrentFlag = currentFlag.ToBoolean();
			this.Gender = gender.ToString();
			this.HireDate = hireDate.ToDateTime();
			this.JobTitle = jobTitle.ToString();
			this.LoginID = loginID.ToString();
			this.MaritalStatus = maritalStatus.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NationalIDNumber = nationalIDNumber.ToString();
			this.OrganizationLevel = organizationLevel;
			this.OrganizationNode = organizationNode;
			this.Rowguid = rowguid.ToGuid();
			this.SalariedFlag = salariedFlag.ToBoolean();
			this.SickLeaveHours = sickLeaveHours;
			this.VacationHours = vacationHours;
		}

		public DateTime BirthDate { get; set; }
		public int BusinessEntityID { get; set; }
		public bool CurrentFlag { get; set; }
		public string Gender { get; set; }
		public DateTime HireDate { get; set; }
		public string JobTitle { get; set; }
		public string LoginID { get; set; }
		public string MaritalStatus { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string NationalIDNumber { get; set; }
		public Nullable<short> OrganizationLevel { get; set; }
		public Nullable<Guid> OrganizationNode { get; set; }
		public Guid Rowguid { get; set; }
		public bool SalariedFlag { get; set; }
		public short SickLeaveHours { get; set; }
		public short VacationHours { get; set; }

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

		public void DisableAllFields()
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
    <Hash>c0a37a76c2fa0bec49ef379f7596807e</Hash>
</Codenesium>*/