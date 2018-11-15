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

		public virtual ApiLinkClientRequestModel MapClientResponseToRequest(
			ApiLinkClientResponseModel response)
		{
			var request = new ApiLinkClientRequestModel();
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
	}
}

/*<Codenesium>
    <Hash>ca49b2119a9de9fdce886229a28c6e82</Hash>
</Codenesium>*/