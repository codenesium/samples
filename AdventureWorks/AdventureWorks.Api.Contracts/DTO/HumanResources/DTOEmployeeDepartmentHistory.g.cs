using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOEmployeeDepartmentHistory: AbstractDTO
	{
		public DTOEmployeeDepartmentHistory() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          short departmentID,
		                          Nullable<DateTime> endDate,
		                          DateTime modifiedDate,
		                          int shiftID,
		                          DateTime startDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.DepartmentID = departmentID;
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ShiftID = shiftID.ToInt();
			this.StartDate = startDate.ToDateTime();
		}

		public int BusinessEntityID { get; set; }
		public short DepartmentID { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ShiftID { get; set; }
		public DateTime StartDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>9b81aa7be65de08e96068833e3292d3f</Hash>
</Codenesium>*/