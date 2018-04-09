using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Employee", Schema="HumanResources")]
	public partial class EFEmployee
	{
		public EFEmployee()
		{}

		public void SetProperties(int businessEntityID,
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
			this.BusinessEntityID = businessEntityID.ToInt();
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
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("NationalIDNumber", TypeName="nvarchar(15)")]
		public string NationalIDNumber {get; set;}

		[Column("LoginID", TypeName="nvarchar(256)")]
		public string LoginID {get; set;}

		[Column("OrganizationNode", TypeName="hierarchyid(892)")]
		public Nullable<Guid> OrganizationNode {get; set;}

		[Column("OrganizationLevel", TypeName="smallint")]
		public Nullable<short> OrganizationLevel {get; set;}

		[Column("JobTitle", TypeName="nvarchar(50)")]
		public string JobTitle {get; set;}

		[Column("BirthDate", TypeName="date")]
		public DateTime BirthDate {get; set;}

		[Column("MaritalStatus", TypeName="nchar(1)")]
		public string MaritalStatus {get; set;}

		[Column("Gender", TypeName="nchar(1)")]
		public string Gender {get; set;}

		[Column("HireDate", TypeName="date")]
		public DateTime HireDate {get; set;}

		[Column("SalariedFlag", TypeName="bit")]
		public bool SalariedFlag {get; set;}

		[Column("VacationHours", TypeName="smallint")]
		public short VacationHours {get; set;}

		[Column("SickLeaveHours", TypeName="smallint")]
		public short SickLeaveHours {get; set;}

		[Column("CurrentFlag", TypeName="bit")]
		public bool CurrentFlag {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }
	}
}

/*<Codenesium>
    <Hash>5c91dc4fbf7375b792f38e5e33c050e3</Hash>
</Codenesium>*/