using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiIncludedColumnTestServerModelMapper
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
    <Hash>f81b4cdf3fb76aa256469be1f45d9711</Hash>
</Codenesium>*/