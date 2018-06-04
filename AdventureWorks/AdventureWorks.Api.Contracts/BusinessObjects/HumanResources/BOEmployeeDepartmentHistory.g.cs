using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOEmployeeDepartmentHistory: AbstractBusinessObject
	{
		public BOEmployeeDepartmentHistory() : base()
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

		public int BusinessEntityID { get; private set; }
		public short DepartmentID { get; private set; }
		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ShiftID { get; private set; }
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8935096dd18513580634593be2cecc66</Hash>
</Codenesium>*/