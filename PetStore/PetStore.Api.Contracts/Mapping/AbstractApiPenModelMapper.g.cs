using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public abstract class AbstractApiPenModelMapper
	{
		public virtual ApiPenResponseModel MapRequestToResponse(
			int id,
			ApiPenRequestModel request)
		{
			var response = new ApiPenResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPenRequestModel MapResponseToRequest(
			ApiPenResponseModel response)
		{
			var request = new ApiPenRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPenRequestModel> CreatePatch(ApiPenRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPenRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0929201aa6cb4076253127a4927d6ebf</Hash>
</Codenesium>*/