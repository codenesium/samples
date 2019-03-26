using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCountryRegionServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			string countryRegionCode,
			DateTime modifiedDate,
			string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b04f4369164025cb01d394660229eb5b</Hash>
</Codenesium>*/