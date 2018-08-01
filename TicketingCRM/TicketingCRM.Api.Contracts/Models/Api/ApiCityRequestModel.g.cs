using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiCityRequestModel : AbstractApiRequestModel
	{
		public ApiCityRequestModel()
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
		public string Name { get; private set; }

		[JsonProperty]
		public int ProvinceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>202177c5896ab4b807cd72b9d680c2bc</Hash>
</Codenesium>*/