using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALJobCandidateMapper
	{
		JobCandidate MapModelToEntity(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel model);

		ApiJobCandidateServerResponseModel MapEntityToModel(
			JobCandidate item);

		List<ApiJobCandidateServerResponseModel> MapEntityToModel(
			List<JobCandidate> items);
	}
}

/*<Codenesium>
    <Hash>acbf654b41b132402c9d5f8442394d4c</Hash>
</Codenesium>*/