using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiClaspServerModelMapper : IApiClaspServerModelMapper
	{
		public virtual ApiClaspServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClaspServerRequestModel request)
		{
			var response = new ApiClaspServerResponseModel();
			response.SetProperties(id,
			                       request.NextChainId,
			                       request.PreviousChainId);
			return response;
		}

		public virtual ApiClaspServerRequestModel MapServerResponseToRequest(
			ApiClaspServerResponseModel response)
		{
			var request = new ApiClaspServerRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}

		public virtual ApiClaspClientRequestModel MapServerResponseToClientRequest(
			ApiClaspServerResponseModel response)
		{
			var request = new ApiClaspClientRequestModel();
			request.SetProperties(
				response.NextChainId,
				response.PreviousChainId);
			return request;
		}

		public JsonPatchDocument<ApiClaspServerRequestModel> CreatePatch(ApiClaspServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClaspServerRequestModel>();
			patch.Replace(x => x.NextChainId, model.NextChainId);
			patch.Replace(x => x.PreviousChainId, model.PreviousChainId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>edbbd2b3b95967cedf8a120b069a421c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/