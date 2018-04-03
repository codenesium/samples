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
		public int businessEntityID {get; set;}
		public string nationalIDNumber {get; set;}
		public string loginID {get; set;}
		public Nullable<Guid> organizationNode {get; set;}
		public Nullable<short> organizationLevel {get; set;}
		public string jobTitle {get; set;}
		public DateTime birthDate {get; set;}
		public string maritalStatus {get; set;}
		public string gender {get; set;}
		public DateTime hireDate {get; set;}
		public bool salariedFlag {get; set;}
		public short vacationHours {get; set;}
		public short sickLeaveHours {get; set;}
		public bool currentFlag {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7d5f1b944555f230615a3e8092abd23d</Hash>
</Codenesium>*/