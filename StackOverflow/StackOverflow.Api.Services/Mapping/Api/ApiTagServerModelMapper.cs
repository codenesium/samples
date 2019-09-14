using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiTagServerModelMapper : IApiTagServerModelMapper
	{
		public virtual ApiTagServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTagServerRequestModel request)
		{
			var response = new ApiTagServerResponseModel();
			response.SetProperties(id,
			                       request.Count,
			                       request.ExcerptPostId,
			                       request.TagName,
			                       request.WikiPostId);
			return response;
		}

		public virtual ApiTagServerRequestModel MapServerResponseToRequest(
			ApiTagServerResponseModel response)
		{
			var request = new ApiTagServerRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public virtual ApiTagClientRequestModel MapServerResponseToClientRequest(
			ApiTagServerResponseModel response)
		{
			var request = new ApiTagClientRequestModel();
			request.SetProperties(
				response.Count,
				response.ExcerptPostId,
				response.TagName,
				response.WikiPostId);
			return request;
		}

		public JsonPatchDocument<ApiTagServerRequestModel> CreatePatch(ApiTagServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTagServerRequestModel>();
			patch.Replace(x => x.Count, model.Count);
			patch.Replace(x => x.ExcerptPostId, model.ExcerptPostId);
			patch.Replace(x => x.TagName, model.TagName);
			patch.Replace(x => x.WikiPostId, model.WikiPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ef97751b15ad7b1bc7da5e338536282c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/