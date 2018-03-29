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
		public int BusinessEntityID {get; set;}
		public short DepartmentID {get; set;}
		public int ShiftID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
		[ForeignKey("DepartmentID")]
		public virtual EFDepartment DepartmentRef { get; set; }
		[ForeignKey("ShiftID")]
		public virtual EFShift ShiftRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>3dc2d073c678f68f03e937f4bd32fa2d</Hash>
</Codenesium>*/