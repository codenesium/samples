using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductListPriceHistory
	{
		public POCOProductListPriceHistory()
		{}

		public POCOProductListPriceHistory(int productID,
		                                   DateTime startDate,
		                                   Nullable<DateTime> endDate,
		                                   decimal listPrice,
		                                   DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public decimal ListPrice {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
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
		public bool ShouldSerializeListPriceValue {get; set;} = true;

		public bool ShouldSerializeListPrice()
		{
			return ShouldSerializeListPriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>d5e1f94f0f8d035d440803d117112227</Hash>
</Codenesium>*/