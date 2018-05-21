using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployeePayHistory: AbstractPOCO
	{
		public POCOEmployeePayHistory() : base()
		{}

		public POCOEmployeePayHistory(
			int businessEntityID,
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
		}

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int PayFrequency { get; set; }
		public decimal Rate { get; set; }
		public DateTime RateChangeDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePayFrequencyValue { get; set; } = true;

		public bool ShouldSerializePayFrequency()
		{
			return this.ShouldSerializePayFrequencyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateValue { get; set; } = true;

		public bool ShouldSerializeRate()
		{
			return this.ShouldSerializeRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateChangeDateValue { get; set; } = true;

		public bool ShouldSerializeRateChangeDate()
		{
			return this.ShouldSerializeRateChangeDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePayFrequencyValue = false;
			this.ShouldSerializeRateValue = false;
			this.ShouldSerializeRateChangeDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5eca8127e21390bb876bcc330f0b0bfe</Hash>
</Codenesium>*/