using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public abstract class AbstractApiProductServerModelMapper
	{
		public virtual ApiProductServerResponseModel MapServerRequestToResponse(
			int id,
			ApiProductServerRequestModel request)
		{
			var response = new ApiProductServerResponseModel();
			response.SetProperties(id,
			                       request.Active,
			                       request.Description,
			                       request.Name,
			                       request.Price,
			                       request.Quantity);
			return response;
		}

		public virtual ApiProductServerRequestModel MapServerResponseToRequest(
			ApiProductServerResponseModel response)
		{
			var request = new ApiProductServerRequestModel();
			request.SetProperties(
				response.Active,
				response.Description,
				response.Name,
				response.Price,
				response.Quantity);
			return request;
		}

		public virtual ApiProductClientRequestModel MapServerResponseToClientRequest(
			ApiProductServerResponseModel response)
		{
			var request = new ApiProductClientRequestModel();
			request.SetProperties(
				response.Active,
				response.Description,
				response.Name,
				response.Price,
				response.Quantity);
			return request;
		}

		public JsonPatchDocument<ApiProductServerRequestModel> CreatePatch(ApiProductServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductServerRequestModel>();
			patch.Replace(x => x.Active, model.Active);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Price, model.Price);
			patch.Replace(x => x.Quantity, model.Quantity);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>88759126e993e7769298475329915c93</Hash>
</Codenesium>*/