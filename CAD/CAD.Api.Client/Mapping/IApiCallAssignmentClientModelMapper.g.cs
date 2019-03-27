using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallAssignmentModelMapper
	{
		ApiCallAssignmentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallAssignmentClientRequestModel request);

		ApiCallAssignmentClientRequestModel MapClientResponseToRequest(
			ApiCallAssignmentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>fa5e5dc320edc0bb4ef94a5268c3033f</Hash>
</Codenesium>*/