using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallAssignmentModelMapper
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
    <Hash>62c760e41980b680278b3776d0e4d812</Hash>
</Codenesium>*/