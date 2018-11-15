using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiCityClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int provinceId)
		{
			this.Id = id;
			this.Name = name;
			this.ProvinceId = provinceId;

			this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProvinceId { get; private set; }

		[JsonProperty]
		public string ProvinceIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>bdf7187954b0c41d3fe22738afe13f31</Hash>
</Codenesium>*/