using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiLinkModelMapper : IApiLinkModelMapper
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
    <Hash>569ca5bb08c281ea892fb36683251f47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/