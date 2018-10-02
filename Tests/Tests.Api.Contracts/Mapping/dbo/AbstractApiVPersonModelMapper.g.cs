using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiVPersonModelMapper
	{
		public virtual ApiVPersonResponseModel MapRequestToResponse(
			int personId,
			ApiVPersonRequestModel request)
		{
			var response = new ApiVPersonResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiVPersonRequestModel MapResponseToRequest(
			ApiVPersonResponseModel response)
		{
			var request = new ApiVPersonRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public JsonPatchDocument<ApiVPersonRequestModel> CreatePatch(ApiVPersonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVPersonRequestModel>();
			patch.Replace(x => x.PersonName, model.PersonName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d304e6f69f15255ef4b83240c7dc3a5c</Hash>
</Codenesium>*/