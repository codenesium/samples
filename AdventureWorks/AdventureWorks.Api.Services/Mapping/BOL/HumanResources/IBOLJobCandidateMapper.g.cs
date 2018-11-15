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
			ApiJobCandidateServerRequestModel model);

		ApiJobCandidateServerResponseModel MapBOToModel(
			BOJobCandidate boJobCandidate);

		List<ApiJobCandidateServerResponseModel> MapBOToModel(
			List<BOJobCandidate> items);
	}
}

/*<Codenesium>
    <Hash>a2b60a3d81c85e78aa02438e34f753fb</Hash>
</Codenesium>*/