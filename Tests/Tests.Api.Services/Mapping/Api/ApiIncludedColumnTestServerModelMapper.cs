using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiIncludedColumnTestServerModelMapper : IApiIncludedColumnTestServerModelMapper
	{
		public virtual ApiIncludedColumnTestServerResponseModel MapServerRequestToResponse(
			int id,
			ApiIncludedColumnTestServerRequestModel request)
		{
			var response = new ApiIncludedColumnTestServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Name2);
			return response;
		}

		public virtual ApiIncludedColumnTestServerRequestModel MapServerResponseToRequest(
			ApiIncludedColumnTestServerResponseModel response)
		{
			var request = new ApiIncludedColumnTestServerRequestModel();
			request.SetProperties(
				response.Name,
				response.Name2);
			return request;
		}

		public virtual ApiIncludedColumnTestClientRequestModel MapServerResponseToClientRequest(
			ApiIncludedColumnTestServerResponseModel response)
		{
			var request = new ApiIncludedColumnTestClientRequestModel();
			request.SetProperties(
				response.Name,
				response.Name2);
			return request;
		}

		public JsonPatchDocument<ApiIncludedColumnTestServerRequestModel> CreatePatch(ApiIncludedColumnTestServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiIncludedColumnTestServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Name2, model.Name2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>647e32567adfcb241a8c9af6a1206d7f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/