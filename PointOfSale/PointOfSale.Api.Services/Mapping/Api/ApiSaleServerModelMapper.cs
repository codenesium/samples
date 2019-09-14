using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiSaleServerModelMapper : IApiSaleServerModelMapper
	{
		public virtual ApiSaleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleServerRequestModel request)
		{
			var response = new ApiSaleServerResponseModel();
			response.SetProperties(id,
			                       request.CustomerId,
			                       request.Date);
			return response;
		}

		public virtual ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleServerRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.Date);
			return request;
		}

		public virtual ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.Date);
			return request;
		}

		public JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleServerRequestModel>();
			patch.Replace(x => x.CustomerId, model.CustomerId);
			patch.Replace(x => x.Date, model.Date);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2cdb4ea286d9bb51c1affd0b0ce3c3f5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/