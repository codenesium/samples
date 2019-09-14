using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiCityServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int provinceId)
		{
			this.Id = id;
			this.Name = name;
			this.ProvinceId = provinceId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProvinceId { get; private set; }

		[JsonProperty]
		public string ProvinceIdEntity { get; private set; } = RouteConstants.Provinces;

		[JsonProperty]
		public ApiProvinceServerResponseModel ProvinceIdNavigation { get; private set; }

		public void SetProvinceIdNavigation(ApiProvinceServerResponseModel value)
		{
			this.ProvinceIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>52746663609cfd97f0bd1fed00c5adec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/