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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("DepartmentID", TypeName="smallint")]
		public short DepartmentID {get; set;}

		[Column("ShiftID", TypeName="tinyint")]
		public int ShiftID {get; set;}

		[Column("StartDate", TypeName="date")]
		public DateTime StartDate {get; set;}

		[Column("EndDate", TypeName="date")]
		public Nullable<DateTime> EndDate {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFEmployee Employee { get; set; }

		public virtual EFDepartment Department { get; set; }

		public virtual EFShift Shift { get; set; }
	}
}

/*<Codenesium>
    <Hash>7ac85e8c1b925070bab87b9eacc0e634</Hash>
</Codenesium>*/