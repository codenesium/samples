using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkServerModelMapper
	{
		public virtual ApiLinkServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkServerRequestModel request)
		{
			var response = new ApiLinkServerResponseModel();
			response.SetProperties(id,
			                       request.AssignedMachineId,
			                       request.ChainId,
			                       request.DateCompleted,
			                       request.DateStarted,
			                       request.DynamicParameters,
			                       request.ExternalId,
			                       request.LinkStatusId,
			                       request.Name,
			                       request.Order,
			                       request.Response,
			                       request.StaticParameters,
			                       request.TimeoutInSeconds);
			return response;
		}

		public virtual ApiLinkServerRequestModel MapServerResponseToRequest(
			ApiLinkServerResponseModel response)
		{
			var request = new ApiLinkServerRequestModel();
			request.SetProperties(
				response.AssignedMachineId,
				response.ChainId,
				response.DateCompleted,
				response.DateStarted,
				response.DynamicParameters,
				response.ExternalId,
				response.LinkStatusId,
				response.Name,
				response.Order,
				response.Response,
				response.StaticParameters,
				response.TimeoutInSeconds);
			return request;
		}

		public virtual ApiLinkClientRequestModel MapServerResponseToClientRequest(
			ApiLinkServerResponseModel response)
		{
			var request = new ApiLinkClientRequestModel();
			request.SetProperties(
				response.AssignedMachineId,
				response.ChainId,
				response.DateCompleted,
				response.DateStarted,
				response.DynamicParameters,
				response.ExternalId,
				response.LinkStatusId,
				response.Name,
				response.Order,
				response.Response,
				response.StaticParameters,
				response.TimeoutInSeconds);
			return request;
		}

		public JsonPatchDocument<ApiLinkServerRequestModel> CreatePatch(ApiLinkServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkServerRequestModel>();
			patch.Replace(x => x.AssignedMachineId, model.AssignedMachineId);
			patch.Replace(x => x.ChainId, model.ChainId);
			patch.Replace(x => x.DateCompleted, model.DateCompleted);
			patch.Replace(x => x.DateStarted, model.DateStarted);
			patch.Replace(x => x.DynamicParameters, model.DynamicParameters);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.LinkStatusId, model.LinkStatusId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Order, model.Order);
			patch.Replace(x => x.Response, model.Response);
			patch.Replace(x => x.StaticParameters, model.StaticParameters);
			patch.Replace(x => x.TimeoutInSeconds, model.TimeoutInSeconds);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>70fc23213c9c9100170e1f8cb6c92118</Hash>
</Codenesium>*/