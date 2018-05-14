using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployeeDepartmentHistory
	{
		public POCOEmployeeDepartmentHistory()
		{}

		public POCOEmployeeDepartmentHistory(
			int businessEntityID,
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

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDepartmentIDValue { get; set; } = true;

		public bool ShouldSerializeDepartmentID()
		{
			return this.ShouldSerializeDepartmentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShiftIDValue { get; set; } = true;

		public bool ShouldSerializeShiftID()
		{
			return this.ShouldSerializeShiftIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeDepartmentIDValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeShiftIDValue = false;
			this.ShouldSerializeStartDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6fdf8b230bc59f6be9771215df24080d</Hash>
</Codenesium>*/