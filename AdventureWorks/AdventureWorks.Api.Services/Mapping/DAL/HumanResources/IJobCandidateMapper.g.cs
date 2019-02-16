using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALJobCandidateMapper
	{
		JobCandidate MapModelToBO(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel model);

		ApiJobCandidateServerResponseModel MapBOToModel(
			JobCandidate item);

		List<ApiJobCandidateServerResponseModel> MapBOToModel(
			List<JobCandidate> items);
	}
}

/*<Codenesium>
    <Hash>4957ebc962bce6d6866528a2dbff5a7e</Hash>
</Codenesium>*/