using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiLinkModelMapper
	{
		public virtual ApiLinkResponseModel MapRequestToResponse(
			int id,
			ApiLinkRequestModel request)
		{
			var response = new ApiLinkResponseModel();
			response.SetProperties(id,
			                       request.AssignedMachineId,
			                       request.ChainId,
			                       request.DateCompleted,
			                       request.DateStarted,
			                       request.DynamicParameter,
			                       request.ExternalId,
			                       request.LinkStatusId,
			                       request.Name,
			                       request.Order,
			                       request.Response,
			                       request.StaticParameter,
			                       request.TimeoutInSecond);
			return response;
		}

		public virtual ApiLinkRequestModel MapResponseToRequest(
			ApiLinkResponseModel response)
		{
			var request = new ApiLinkRequestModel();
			request.SetProperties(
				response.AssignedMachineId,
				response.ChainId,
				response.DateCompleted,
				response.DateStarted,
				response.DynamicParameter,
				response.ExternalId,
				response.LinkStatusId,
				response.Name,
				response.Order,
				response.Response,
				response.StaticParameter,
				response.TimeoutInSecond);
			return request;
		}

		public JsonPatchDocument<ApiLinkRequestModel> CreatePatch(ApiLinkRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkRequestModel>();
			patch.Replace(x => x.AssignedMachineId, model.AssignedMachineId);
			patch.Replace(x => x.ChainId, model.ChainId);
			patch.Replace(x => x.DateCompleted, model.DateCompleted);
			patch.Replace(x => x.DateStarted, model.DateStarted);
			patch.Replace(x => x.DynamicParameter, model.DynamicParameter);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.LinkStatusId, model.LinkStatusId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Order, model.Order);
			patch.Replace(x => x.Response, model.Response);
			patch.Replace(x => x.StaticParameter, model.StaticParameter);
			patch.Replace(x => x.TimeoutInSecond, model.TimeoutInSecond);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>aafc8a138afe6ac07124c3a3ea3fac73</Hash>
</Codenesium>*/