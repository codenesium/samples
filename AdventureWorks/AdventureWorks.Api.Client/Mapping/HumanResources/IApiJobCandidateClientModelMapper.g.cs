using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiJobCandidateModelMapper
	{
		ApiJobCandidateClientResponseModel MapClientRequestToResponse(
			int jobCandidateID,
			ApiJobCandidateClientRequestModel request);

		ApiJobCandidateClientRequestModel MapClientResponseToRequest(
			ApiJobCandidateClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>bb415f59b443d87d0dedc2dc8ea84b3f</Hash>
</Codenesium>*/