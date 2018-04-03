using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class EFEmployeeDepartmentHistory
	{
		public EFEmployeeDepartmentHistory()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public short departmentID {get; set;}
		public int shiftID {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>25e987aa4d5fb2d9e11c8e91357db21a</Hash>
</Codenesium>*/