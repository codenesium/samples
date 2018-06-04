using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductCostHistoryResponseModel: AbstractApiResponseModel
	{
		public ApiProductCostHistoryResponseModel() : base()
		{}

		public void SetProperties(
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int productID,
			decimal standardCost,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.StandardCost = standardCost.ToDecimal();
			this.StartDate = startDate.ToDateTime();
		}

		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public decimal StandardCost { get; private set; }
		public DateTime StartDate { get; private set; }

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
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStandardCostValue { get; set; } = true;

		public bool ShouldSerializeStandardCost()
		{
			return this.ShouldSerializeStandardCostValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeStandardCostValue = false;
			this.ShouldSerializeStartDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9e72e387f791787421616f8e2ca7848b</Hash>
</Codenesium>*/