using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCurrencyClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>bb9ec92f6b21bc13a8332e84aeb78276</Hash>
</Codenesium>*/