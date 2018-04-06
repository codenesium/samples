using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Employee", Schema="HumanResources")]
	public partial class EFEmployee
	{
		public EFEmployee()
		{}

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

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e0b1d04a0de51f1066030203d4c32cc3</Hash>
</Codenesium>*/