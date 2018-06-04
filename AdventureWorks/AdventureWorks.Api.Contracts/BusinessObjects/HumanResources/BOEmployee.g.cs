using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOEmployee: AbstractBusinessObject
	{
		public BOEmployee() : base()
		{}

		public void SetProperties(int businessEntityID,
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
		                          Nullable<Guid> organizationNode,
		                          Guid rowguid,
		                          bool salariedFlag,
		                          short sickLeaveHours,
		                          short vacationHours)
		{
			this.BirthDate = birthDate.ToDateTime();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CurrentFlag = currentFlag.ToBoolean();
			this.Gender = gender;
			this.HireDate = hireDate.ToDateTime();
			this.JobTitle = jobTitle;
			this.LoginID = loginID;
			this.MaritalStatus = maritalStatus;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NationalIDNumber = nationalIDNumber;
			this.OrganizationLevel = organizationLevel;
			this.OrganizationNode = organizationNode.ToNullableGuid();
			this.Rowguid = rowguid.ToGuid();
			this.SalariedFlag = salariedFlag.ToBoolean();
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
	}
}

/*<Codenesium>
    <Hash>df7fc9e2716fedd4ad16ed44877958c0</Hash>
</Codenesium>*/