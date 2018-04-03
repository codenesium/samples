using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Department", Schema="HumanResources")]
	public partial class EFDepartment
	{
		public EFDepartment()
		{}

		[Key]
		public short departmentID {get; set;}
		public string name {get; set;}
		public string groupName {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>1b001c1dab0c90c85cafcfdee6bc377e</Hash>
</Codenesium>*/