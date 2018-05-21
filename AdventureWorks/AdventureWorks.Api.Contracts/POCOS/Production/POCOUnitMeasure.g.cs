using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOUnitMeasure: AbstractPOCO
	{
		public POCOUnitMeasure() : base()
		{}

		public POCOUnitMeasure(
			DateTime modifiedDate,
			string name,
			string unitMeasureCode)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.UnitMeasureCode = unitMeasureCode;
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public string UnitMeasureCode { get; set; }

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

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return this.ShouldSerializeUnitMeasureCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f494cd132d20ee466cc3129780e98f8e</Hash>
</Codenesium>*/