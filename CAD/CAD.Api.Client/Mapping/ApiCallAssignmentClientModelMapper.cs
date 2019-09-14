using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiCallAssignmentModelMapper : IApiCallAssignmentModelMapper
	{
		public virtual ApiCallAssignmentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallAssignmentClientRequestModel request)
		{
			var response = new ApiCallAssignmentClientResponseModel();
			response.SetProperties(id,
			                       request.CallId,
			                       request.UnitId);
			return response;
		}

		public virtual ApiCallAssignmentClientRequestModel MapClientResponseToRequest(
			ApiCallAssignmentClientResponseModel response)
		{
			var request = new ApiCallAssignmentClientRequestModel();
			request.SetProperties(
				response.CallId,
				response.UnitId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ea50051bf456ac57edae88fe924701ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/