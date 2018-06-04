using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiUnitMeasureResponseModel: AbstractApiResponseModel
	{
		public ApiUnitMeasureResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			string unitMeasureCode)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.UnitMeasureCode = unitMeasureCode;
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public string UnitMeasureCode { get; private set; }

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
    <Hash>3f3e5a04d2679691acc503554b589b12</Hash>
</Codenesium>*/