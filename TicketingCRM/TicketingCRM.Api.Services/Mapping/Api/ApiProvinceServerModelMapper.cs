using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiProvinceServerModelMapper : IApiProvinceServerModelMapper
	{
		public virtual ApiProvinceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiProvinceServerRequestModel request)
		{
			var response = new ApiProvinceServerResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name);
			return response;
		}

		public virtual ApiProvinceServerRequestModel MapServerResponseToRequest(
			ApiProvinceServerResponseModel response)
		{
			var request = new ApiProvinceServerRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name);
			return request;
		}

		public virtual ApiProvinceClientRequestModel MapServerResponseToClientRequest(
			ApiProvinceServerResponseModel response)
		{
			var request = new ApiProvinceClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiProvinceServerRequestModel> CreatePatch(ApiProvinceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProvinceServerRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>76a698c120e7a5ea267f105cc24e657f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/