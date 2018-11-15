using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiCityServerModelMapper
	{
		public virtual ApiCityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCityServerRequestModel request)
		{
			var response = new ApiCityServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.ProvinceId);
			return response;
		}

		public virtual ApiCityServerRequestModel MapServerResponseToRequest(
			ApiCityServerResponseModel response)
		{
			var request = new ApiCityServerRequestModel();
			request.SetProperties(
				response.Name,
				response.ProvinceId);
			return request;
		}

		public virtual ApiCityClientRequestModel MapServerResponseToClientRequest(
			ApiCityServerResponseModel response)
		{
			var request = new ApiCityClientRequestModel();
			request.SetProperties(
				response.Name,
				response.ProvinceId);
			return request;
		}

		public JsonPatchDocument<ApiCityServerRequestModel> CreatePatch(ApiCityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCityServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProvinceId, model.ProvinceId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3d6ffc2cf4c6e9381e308cfe416403cf</Hash>
</Codenesium>*/