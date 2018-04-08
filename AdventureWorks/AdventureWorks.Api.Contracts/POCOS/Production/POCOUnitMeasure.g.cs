using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOUnitMeasure
	{
		public POCOUnitMeasure()
		{}

		public POCOUnitMeasure(string unitMeasureCode,
		                       string name,
		                       DateTime modifiedDate)
		{
			this.UnitMeasureCode = unitMeasureCode;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string UnitMeasureCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue {get; set;} = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return ShouldSerializeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeUnitMeasureCodeValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>cad6bc6bc36bc1aaeca314cb2054de7c</Hash>
</Codenesium>*/