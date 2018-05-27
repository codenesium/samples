using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiLocationResponseModel: AbstractApiResponseModel
	{
		public ApiLocationResponseModel() : base()
		{}

		public void SetProperties(
			decimal availability,
			decimal costRate,
			short locationID,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public decimal Availability { get; set; }
		public decimal CostRate { get; set; }
		public short LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAvailabilityValue { get; set; } = true;

		public bool ShouldSerializeAvailability()
		{
			return this.ShouldSerializeAvailabilityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCostRateValue { get; set; } = true;

		public bool ShouldSerializeCostRate()
		{
			return this.ShouldSerializeCostRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAvailabilityValue = false;
			this.ShouldSerializeCostRateValue = false;
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ff0388632e331557e6bb3adf7e162dc4</Hash>
</Codenesium>*/