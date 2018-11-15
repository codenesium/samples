using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiBadgeServerModelMapper
	{
		public virtual ApiBadgeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBadgeServerRequestModel request)
		{
			var response = new ApiBadgeServerResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.Name,
			                       request.UserId);
			return response;
		}

		public virtual ApiBadgeServerRequestModel MapServerResponseToRequest(
			ApiBadgeServerResponseModel response)
		{
			var request = new ApiBadgeServerRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}

		public virtual ApiBadgeClientRequestModel MapServerResponseToClientRequest(
			ApiBadgeServerResponseModel response)
		{
			var request = new ApiBadgeClientRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiBadgeServerRequestModel> CreatePatch(ApiBadgeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBadgeServerRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>021f66cf2fff9c18385a06d6ccfef577</Hash>
</Codenesium>*/