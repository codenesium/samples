using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiOrganizationServerModelMapper : IApiOrganizationServerModelMapper
	{
		public virtual ApiOrganizationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOrganizationServerRequestModel request)
		{
			var response = new ApiOrganizationServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOrganizationServerRequestModel MapServerResponseToRequest(
			ApiOrganizationServerResponseModel response)
		{
			var request = new ApiOrganizationServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiOrganizationClientRequestModel MapServerResponseToClientRequest(
			ApiOrganizationServerResponseModel response)
		{
			var request = new ApiOrganizationClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiOrganizationServerRequestModel> CreatePatch(ApiOrganizationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOrganizationServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>557aabf88906b96bd3363f53bf1d746b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/