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

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
		[ForeignKey("DepartmentID")]
		public virtual EFDepartment DepartmentRef { get; set; }
		[ForeignKey("ShiftID")]
		public virtual EFShift ShiftRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>310fc845c51922a515c7967509de4f9f</Hash>
</Codenesium>*/