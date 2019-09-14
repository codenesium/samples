using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryTypeServerModelMapper : IApiPostHistoryTypeServerModelMapper
	{
		public virtual ApiPostHistoryTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryTypeServerRequestModel request)
		{
			var response = new ApiPostHistoryTypeServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostHistoryTypeServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiPostHistoryTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> CreatePatch(ApiPostHistoryTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryTypeServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f2dc294aee7d6bf19cf279fac1787f90</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/