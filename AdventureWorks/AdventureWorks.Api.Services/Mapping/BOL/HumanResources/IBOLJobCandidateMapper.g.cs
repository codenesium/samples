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
			List<BOJobCandidate> items);
	}
}

/*<Codenesium>
    <Hash>b4d3b8e171bfa6cddb27a6eba512d123</Hash>
</Codenesium>*/