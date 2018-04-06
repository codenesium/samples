using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployeeDepartmentHistory
	{
		public POCOEmployeeDepartmentHistory()
		{}

		public POCOEmployeeDepartmentHistory(int businessEntityID,
		                                     short departmentID,
		                                     int shiftID,
		                                     DateTime startDate,
		                                     Nullable<DateTime> endDate,
		                                     DateTime modifiedDate)
		{
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Employee");
			DepartmentID = new ReferenceEntity<short>(departmentID,
			                                          "Department");
			ShiftID = new ReferenceEntity<int>(shiftID,
			                                   "Shift");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public ReferenceEntity<short>DepartmentID {get; set;}
		public ReferenceEntity<int>ShiftID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDepartmentIDValue {get; set;} = true;

		public bool ShouldSerializeDepartmentID()
		{
			return ShouldSerializeDepartmentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShiftIDValue {get; set;} = true;

		public bool ShouldSerializeShiftID()
		{
			return ShouldSerializeShiftIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue {get; set;} = true;

		public bool ShouldSerializeStartDate()
		{
			return ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue {get; set;} = true;

		public bool ShouldSerializeEndDate()
		{
			return ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeDepartmentIDValue = false;
			this.ShouldSerializeShiftIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3ee41127cf8c6b7d8f36d384ad335d38</Hash>
</Codenesium>*/