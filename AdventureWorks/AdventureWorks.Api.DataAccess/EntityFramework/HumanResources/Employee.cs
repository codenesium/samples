using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Employee", Schema="HumanResources")]
	public partial class Employee: AbstractEntityFrameworkPOCO
	{
		public Employee()
		{}

		public void SetProperties(
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

		[Column("BirthDate", TypeName="date")]
		public DateTime BirthDate { get; set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("CurrentFlag", TypeName="bit")]
		public bool CurrentFlag { get; set; }

		[Column("Gender", TypeName="nchar(1)")]
		public string Gender { get; set; }

		[Column("HireDate", TypeName="date")]
		public DateTime HireDate { get; set; }

		[Column("JobTitle", TypeName="nvarchar(50)")]
		public string JobTitle { get; set; }

		[Column("LoginID", TypeName="nvarchar(256)")]
		public string LoginID { get; set; }

		[Column("MaritalStatus", TypeName="nchar(1)")]
		public string MaritalStatus { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("NationalIDNumber", TypeName="nvarchar(15)")]
		public string NationalIDNumber { get; set; }

		[Column("OrganizationLevel", TypeName="smallint")]
		public Nullable<short> OrganizationLevel { get; set; }

		[Column("OrganizationNode", TypeName="hierarchyid(892)")]
		public Nullable<Guid> OrganizationNode { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalariedFlag", TypeName="bit")]
		public bool SalariedFlag { get; set; }

		[Column("SickLeaveHours", TypeName="smallint")]
		public short SickLeaveHours { get; set; }

		[Column("VacationHours", TypeName="smallint")]
		public short VacationHours { get; set; }
	}
}

/*<Codenesium>
    <Hash>c5a4739d51387e8a4897e31c0a9247c6</Hash>
</Codenesium>*/