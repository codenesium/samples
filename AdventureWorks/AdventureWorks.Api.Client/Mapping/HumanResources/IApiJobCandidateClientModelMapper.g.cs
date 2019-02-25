using AdventureWorksNS.Api.Contracts;
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
    <Hash>016ccf1010fcc0b20100d98814f2bf08</Hash>
</Codenesium>*/