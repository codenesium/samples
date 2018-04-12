using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOLocation
	{
		public POCOLocation()
		{}

		public POCOLocation(
			short locationID,
			string name,
			decimal costRate,
			decimal availability,
			DateTime modifiedDate)
		{
			this.LocationID = locationID;
			this.Name = name;
			this.CostRate = costRate;
			this.Availability = availability.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public short LocationID { get; set; }
		public string Name { get; set; }
		public decimal CostRate { get; set; }
		public decimal Availability { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostRateValue { get; set; } = true;

		public bool ShouldSerializeCostRate()
		{
			return this.ShouldSerializeCostRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAvailabilityValue { get; set; } = true;

		public bool ShouldSerializeAvailability()
		{
			return this.ShouldSerializeAvailabilityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeCostRateValue = false;
			this.ShouldSerializeAvailabilityValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>920696d35edf95157c560f756d1ea74e</Hash>
</Codenesium>*/