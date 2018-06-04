using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeeDepartmentHistoryResponseModel: AbstractApiResponseModel
	{
		public ApiEmployeeDepartmentHistoryResponseModel() : base()
		{}

		public void SetProperties(
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

		public int BusinessEntityID { get; private set; }
		public short DepartmentID { get; private set; }
		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ShiftID { get; private set; }
		public DateTime StartDate { get; private set; }

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
    <Hash>c461b8379394f4eac91849de4e968755</Hash>
</Codenesium>*/