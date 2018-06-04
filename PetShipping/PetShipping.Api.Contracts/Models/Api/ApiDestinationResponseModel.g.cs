using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiDestinationResponseModel: AbstractApiResponseModel
	{
		public ApiDestinationResponseModel() : base()
		{}

		public void SetProperties(
			int countryId,
			int id,
			string name,
			int order)
		{
			this.CountryId = countryId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();

			this.CountryIdEntity = nameof(ApiResponse.Countries);
		}

		public int CountryId { get; private set; }
		public string CountryIdEntity { get; set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int Order { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryIdValue { get; set; } = true;

		public bool ShouldSerializeCountryId()
		{
			return this.ShouldSerializeCountryIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderValue { get; set; } = true;

		public bool ShouldSerializeOrder()
		{
			return this.ShouldSerializeOrderValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeOrderValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>2e9573a4237fb6d02a225a2ab101c311</Hash>
</Codenesium>*/