using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiBadgesServerModelMapper
	{
		public virtual ApiBadgesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBadgesServerRequestModel request)
		{
			var response = new ApiBadgesServerResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.Name,
			                       request.UserId);
			return response;
		}

		public virtual ApiBadgesServerRequestModel MapServerResponseToRequest(
			ApiBadgesServerResponseModel response)
		{
			var request = new ApiBadgesServerRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}

		public virtual ApiBadgesClientRequestModel MapServerResponseToClientRequest(
			ApiBadgesServerResponseModel response)
		{
			var request = new ApiBadgesClientRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiBadgesServerRequestModel> CreatePatch(ApiBadgesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBadgesServerRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f7206c9330997a706f2ab6a9e49e1b96</Hash>
</Codenesium>*/