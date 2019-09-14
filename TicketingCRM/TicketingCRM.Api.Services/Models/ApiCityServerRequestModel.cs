using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiCityServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCityServerRequestModel()
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
    <Hash>99341655e85cabb320d5af60e9f91ffa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/