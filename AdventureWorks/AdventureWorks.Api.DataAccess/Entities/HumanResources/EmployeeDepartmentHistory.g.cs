using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class EmployeeDepartmentHistory : AbstractEntity
	{
		public EmployeeDepartmentHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			short departmentID,
			DateTime? endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.DepartmentID = departmentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Key]
		[Column("DepartmentID")]
		public virtual short DepartmentID { get; private set; }

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ShiftID")]
		public virtual int ShiftID { get; private set; }

		[Key]
		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual Employee BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(Employee item)
		{
			this.BusinessEntityIDNavigation = item;
		}

		[ForeignKey("DepartmentID")]
		public virtual Department DepartmentIDNavigation { get; private set; }

		public void SetDepartmentIDNavigation(Department item)
		{
			this.DepartmentIDNavigation = item;
		}

		[ForeignKey("ShiftID")]
		public virtual Shift ShiftIDNavigation { get; private set; }

		public void SetShiftIDNavigation(Shift item)
		{
			this.ShiftIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>37d75880a514b5e4329ed22d795c5064</Hash>
</Codenesium>*/