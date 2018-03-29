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
		public int BusinessEntityID {get; set;}
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
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>5c2b69a3b55671a63dd133ce16ff5a6a</Hash>
</Codenesium>*/