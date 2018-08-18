using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiTableModelMapper
	{
		public virtual ApiTableResponseModel MapRequestToResponse(
			int id,
			ApiTableRequestModel request)
		{
			var response = new ApiTableResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTableRequestModel MapResponseToRequest(
			ApiTableResponseModel response)
		{
			var request = new ApiTableRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTableRequestModel> CreatePatch(ApiTableRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTableRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>67e7c0837ee6d963da7339a9423d723e</Hash>
</Codenesium>*/