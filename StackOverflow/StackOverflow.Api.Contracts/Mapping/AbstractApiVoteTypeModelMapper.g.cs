using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiVoteTypeModelMapper
	{
		public virtual ApiVoteTypeResponseModel MapRequestToResponse(
			int id,
			ApiVoteTypeRequestModel request)
		{
			var response = new ApiVoteTypeResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypeRequestModel MapResponseToRequest(
			ApiVoteTypeResponseModel response)
		{
			var request = new ApiVoteTypeRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVoteTypeRequestModel> CreatePatch(ApiVoteTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteTypeRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>501e8ca1ff508ddfb3b49aeac81fb966</Hash>
</Codenesium>*/