using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiLinkModelMapper
	{
		public virtual ApiLinkClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkClientRequestModel request)
		{
			var response = new ApiLinkClientResponseModel();
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

		public virtual ApiLinkClientRequestModel MapClientResponseToRequest(
			ApiLinkClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>aedc5a94aebed921b6cb2aecfa1db0a9</Hash>
</Codenesium>*/