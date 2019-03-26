using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCurrencyServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			string currencyCode,
			DateTime modifiedDate,
			string name)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public string CurrencyCode { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>77cdb83400320ec5c8db1f072f873417</Hash>
</Codenesium>*/