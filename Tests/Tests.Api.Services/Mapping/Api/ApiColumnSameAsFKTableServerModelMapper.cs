using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiColumnSameAsFKTableServerModelMapper : IApiColumnSameAsFKTableServerModelMapper
	{
		public virtual ApiColumnSameAsFKTableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiColumnSameAsFKTableServerRequestModel request)
		{
			var response = new ApiColumnSameAsFKTableServerResponseModel();
			response.SetProperties(id,
			                       request.Person,
			                       request.PersonId);
			return response;
		}

		public virtual ApiColumnSameAsFKTableServerRequestModel MapServerResponseToRequest(
			ApiColumnSameAsFKTableServerResponseModel response)
		{
			var request = new ApiColumnSameAsFKTableServerRequestModel();
			request.SetProperties(
				response.Person,
				response.PersonId);
			return request;
		}

		public virtual ApiColumnSameAsFKTableClientRequestModel MapServerResponseToClientRequest(
			ApiColumnSameAsFKTableServerResponseModel response)
		{
			var request = new ApiColumnSameAsFKTableClientRequestModel();
			request.SetProperties(
				response.Person,
				response.PersonId);
			return request;
		}

		public JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel> CreatePatch(ApiColumnSameAsFKTableServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiColumnSameAsFKTableServerRequestModel>();
			patch.Replace(x => x.Person, model.Person);
			patch.Replace(x => x.PersonId, model.PersonId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7810042f7fee1d1680c2c4264bd3f019</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/