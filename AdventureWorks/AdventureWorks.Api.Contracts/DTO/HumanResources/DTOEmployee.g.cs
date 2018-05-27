using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOEmployee: AbstractDTO
	{
		public DTOEmployee() : base()
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
	}
}

/*<Codenesium>
    <Hash>dc2d3cc5d74920f152c8755944d4b2b3</Hash>
</Codenesium>*/