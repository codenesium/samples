using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Employee", Schema="HumanResources")]
	public partial class Employee: AbstractEntity
	{
		public Employee()
		{}

		public void SetProperties(
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
		public DateTime BirthDate { get; private set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("CurrentFlag", TypeName="bit")]
		public bool CurrentFlag { get; private set; }

		[Column("Gender", TypeName="nchar(1)")]
		public string Gender { get; private set; }

		[Column("HireDate", TypeName="date")]
		public DateTime HireDate { get; private set; }

		[Column("JobTitle", TypeName="nvarchar(50)")]
		public string JobTitle { get; private set; }

		[Column("LoginID", TypeName="nvarchar(256)")]
		public string LoginID { get; private set; }

		[Column("MaritalStatus", TypeName="nchar(1)")]
		public string MaritalStatus { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("NationalIDNumber", TypeName="nvarchar(15)")]
		public string NationalIDNumber { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("OrganizationLevel", TypeName="smallint")]
		public Nullable<short> OrganizationLevel { get; private set; }

		[Column("OrganizationNode", TypeName="hierarchyid(892)")]
		public Nullable<Guid> OrganizationNode { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("SalariedFlag", TypeName="bit")]
		public bool SalariedFlag { get; private set; }

		[Column("SickLeaveHours", TypeName="smallint")]
		public short SickLeaveHours { get; private set; }

		[Column("VacationHours", TypeName="smallint")]
		public short VacationHours { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2da0d5d295a0cd2129d0afa56b4019bd</Hash>
</Codenesium>*/