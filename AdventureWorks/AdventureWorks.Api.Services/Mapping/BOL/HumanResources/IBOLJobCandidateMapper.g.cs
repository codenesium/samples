using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLJobCandidateMapper
	{
		BOJobCandidate MapModelToBO(
			int jobCandidateID,
			ApiJobCandidateRequestModel model);

		ApiJobCandidateResponseModel MapBOToModel(
			BOJobCandidate boJobCandidate);

		List<ApiJobCandidateResponseModel> MapBOToModel(
			List<BOJobCandidate> items);
	}
}

/*<Codenesium>
    <Hash>0593ebb347dae32245aee03b9fb39079</Hash>
</Codenesium>*/