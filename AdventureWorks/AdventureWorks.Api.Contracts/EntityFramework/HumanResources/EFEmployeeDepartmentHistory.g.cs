using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class EFEmployeeDepartmentHistory
	{
		public EFEmployeeDepartmentHistory()
		{}

		public void SetProperties(int businessEntityID,
		                          short departmentID,
		                          int shiftID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.DepartmentID = departmentID;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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
    <Hash>b656293fad326e62b6131b79fe6a8abd</Hash>
</Codenesium>*/