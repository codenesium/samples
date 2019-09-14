using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiCityClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCityClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int provinceId)
		{
			this.Name = name;
			this.ProvinceId = provinceId;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int ProvinceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6d6471fcd97b22e0c89c6cf45b0f80fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/