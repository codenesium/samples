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
		public virtual EFEmployee Employee { get; set; }
		[ForeignKey("DepartmentID")]
		public virtual EFDepartment Department { get; set; }
		[ForeignKey("ShiftID")]
		public virtual EFShift Shift { get; set; }
	}
}

/*<Codenesium>
    <Hash>589032590beaac6cc3ce436a3bd4843e</Hash>
</Codenesium>*/