using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOLocation
	{
		public POCOLocation()
		{}

		public POCOLocation(short locationID,
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

		public short LocationID {get; set;}
		public string Name {get; set;}
		public decimal CostRate {get; set;}
		public decimal Availability {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue {get; set;} = true;

		public bool ShouldSerializeLocationID()
		{
			return ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostRateValue {get; set;} = true;

		public bool ShouldSerializeCostRate()
		{
			return ShouldSerializeCostRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAvailabilityValue {get; set;} = true;

		public bool ShouldSerializeAvailability()
		{
			return ShouldSerializeAvailabilityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>38a185c3d7a4396523ca4bb093f35ee1</Hash>
</Codenesium>*/