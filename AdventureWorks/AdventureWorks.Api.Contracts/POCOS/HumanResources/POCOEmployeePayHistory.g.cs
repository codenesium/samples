using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployeePayHistory
	{
		public POCOEmployeePayHistory()
		{}

		public POCOEmployeePayHistory(
			int businessEntityID,
			DateTime rateChangeDate,
			decimal rate,
			int payFrequency,
			DateTime modifiedDate)
		{
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate.ToDecimal();
			this.PayFrequency = payFrequency.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.Employees));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public DateTime RateChangeDate { get; set; }
		public decimal Rate { get; set; }
		public int PayFrequency { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateChangeDateValue { get; set; } = true;

		public bool ShouldSerializeRateChangeDate()
		{
			return this.ShouldSerializeRateChangeDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateValue { get; set; } = true;

		public bool ShouldSerializeRate()
		{
			return this.ShouldSerializeRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePayFrequencyValue { get; set; } = true;

		public bool ShouldSerializePayFrequency()
		{
			return this.ShouldSerializePayFrequencyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeRateChangeDateValue = false;
			this.ShouldSerializeRateValue = false;
			this.ShouldSerializePayFrequencyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7224f3675596d95d0e306edeb9ba32ae</Hash>
</Codenesium>*/