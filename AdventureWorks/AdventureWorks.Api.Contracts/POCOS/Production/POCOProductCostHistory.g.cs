using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductCostHistory: AbstractPOCO
	{
		public POCOProductCostHistory() : base()
		{}

		public POCOProductCostHistory(
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

		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public decimal StandardCost { get; set; }
		public DateTime StartDate { get; set; }

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
    <Hash>40afa406d54c412cc210a504e72d9540</Hash>
</Codenesium>*/