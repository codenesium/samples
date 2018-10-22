using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int ProvinceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>589fe1665f9adc5065c07715c9550b04</Hash>
</Codenesium>*/