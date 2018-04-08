using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOEmployeePayHistory
	{
		public POCOEmployeePayHistory()
		{}

		public POCOEmployeePayHistory(int businessEntityID,
		                              DateTime rateChangeDate,
		                              decimal rate,
		                              int payFrequency,
		                              DateTime modifiedDate)
		{
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate;
			this.PayFrequency = payFrequency;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Employee");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public DateTime RateChangeDate {get; set;}
		public decimal Rate {get; set;}
		public int PayFrequency {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateChangeDateValue {get; set;} = true;

		public bool ShouldSerializeRateChangeDate()
		{
			return ShouldSerializeRateChangeDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRateValue {get; set;} = true;

		public bool ShouldSerializeRate()
		{
			return ShouldSerializeRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePayFrequencyValue {get; set;} = true;

		public bool ShouldSerializePayFrequency()
		{
			return ShouldSerializePayFrequencyValue;
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
			this.ShouldSerializeRateChangeDateValue = false;
			this.ShouldSerializeRateValue = false;
			this.ShouldSerializePayFrequencyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>19b45feaad94f3444b5f036f858328f9</Hash>
</Codenesium>*/