using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiOrganizationModelMapper
	{
		public virtual ApiOrganizationResponseModel MapRequestToResponse(
			int id,
			ApiOrganizationRequestModel request)
		{
			var response = new ApiOrganizationResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOrganizationRequestModel MapResponseToRequest(
			ApiOrganizationResponseModel response)
		{
			var request = new ApiOrganizationRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiOrganizationRequestModel> CreatePatch(ApiOrganizationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOrganizationRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8884375a4f9db1d1843dd10152397588</Hash>
</Codenesium>*/