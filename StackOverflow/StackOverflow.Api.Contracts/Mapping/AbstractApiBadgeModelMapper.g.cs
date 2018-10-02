using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiBadgeModelMapper
	{
		public virtual ApiBadgeResponseModel MapRequestToResponse(
			int id,
			ApiBadgeRequestModel request)
		{
			var response = new ApiBadgeResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.Name,
			                       request.UserId);
			return response;
		}

		public virtual ApiBadgeRequestModel MapResponseToRequest(
			ApiBadgeResponseModel response)
		{
			var request = new ApiBadgeRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiBadgeRequestModel> CreatePatch(ApiBadgeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBadgeRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2a6ccd5009b05521eb72e9e446379a7b</Hash>
</Codenesium>*/