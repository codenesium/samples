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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ProvinceId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>7ba4b9c84a22d1bda746168b7c479677</Hash>
</Codenesium>*/