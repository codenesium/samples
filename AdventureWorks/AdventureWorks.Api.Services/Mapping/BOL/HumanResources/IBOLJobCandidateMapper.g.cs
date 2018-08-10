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
    <Hash>1ccc1f84e1c9c60bbfbbc11b6d455e28</Hash>
</Codenesium>*/