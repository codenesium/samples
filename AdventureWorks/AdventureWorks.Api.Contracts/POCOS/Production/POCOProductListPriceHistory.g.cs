using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductListPriceHistory
	{
		public POCOProductListPriceHistory()
		{}

		public POCOProductListPriceHistory(
			int productID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			decimal listPrice,
			DateTime modifiedDate)
		{
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          "Product");
		}

		public ReferenceEntity<int> ProductID { get; set; }
		public DateTime StartDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public decimal ListPrice { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeListPriceValue { get; set; } = true;

		public bool ShouldSerializeListPrice()
		{
			return this.ShouldSerializeListPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeListPriceValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>81c68f5556598cf300c476065e758c4c</Hash>
</Codenesium>*/