using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiUnitServerModelMapper : IApiUnitServerModelMapper
	{
		public virtual ApiUnitServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitServerRequestModel request)
		{
			var response = new ApiUnitServerResponseModel();
			response.SetProperties(id,
			                       request.CallSign);
			return response;
		}

		public virtual ApiUnitServerRequestModel MapServerResponseToRequest(
			ApiUnitServerResponseModel response)
		{
			var request = new ApiUnitServerRequestModel();
			request.SetProperties(
				response.CallSign);
			return request;
		}

		public virtual ApiUnitClientRequestModel MapServerResponseToClientRequest(
			ApiUnitServerResponseModel response)
		{
			var request = new ApiUnitClientRequestModel();
			request.SetProperties(
				response.CallSign);
			return request;
		}

		public JsonPatchDocument<ApiUnitServerRequestModel> CreatePatch(ApiUnitServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUnitServerRequestModel>();
			patch.Replace(x => x.CallSign, model.CallSign);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>466ce649491492bd699490191ae6514d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/