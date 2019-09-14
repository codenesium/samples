using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiCountryServerModelMapper : IApiCountryServerModelMapper
	{
		public virtual ApiCountryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryServerRequestModel request)
		{
			var response = new ApiCountryServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryServerRequestModel MapServerResponseToRequest(
			ApiCountryServerResponseModel response)
		{
			var request = new ApiCountryServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCountryClientRequestModel MapServerResponseToClientRequest(
			ApiCountryServerResponseModel response)
		{
			var request = new ApiCountryClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCountryServerRequestModel> CreatePatch(ApiCountryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b1a875ab8bd4880df640672b23f0f23b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/