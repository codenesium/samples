using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLJobCandidateMapper
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
    <Hash>93494ecf2495824506af3638f81072d0</Hash>
</Codenesium>*/