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
	}
}

/*<Codenesium>
    <Hash>751c50c67cdd37c9903c21022319fc8d</Hash>
</Codenesium>*/