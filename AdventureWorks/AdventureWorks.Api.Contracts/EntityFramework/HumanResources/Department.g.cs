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
		public short DepartmentID {get; set;}
		public string Name {get; set;}
		public string GroupName {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>ca96e3a854bf7c0a7cde343eec56469c</Hash>
</Codenesium>*/