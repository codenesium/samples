using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BOJobCandidate> bos);
	}
}

/*<Codenesium>
    <Hash>e1d2b2f8637605b78d51506b6e6f0498</Hash>
</Codenesium>*/