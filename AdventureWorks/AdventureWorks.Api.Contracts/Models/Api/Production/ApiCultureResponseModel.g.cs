using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCultureResponseModel: AbstractApiResponseModel
	{
		public ApiCultureResponseModel() : base()
		{}

		public void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CultureID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeCultureIDValue { get; set; } = true;

		public bool ShouldSerializeCultureID()
		{
			return this.ShouldSerializeCultureIDValue;
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
			this.ShouldSerializeCultureIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5084a39010c6c6fd74dcccae9e74b4fb</Hash>
</Codenesium>*/