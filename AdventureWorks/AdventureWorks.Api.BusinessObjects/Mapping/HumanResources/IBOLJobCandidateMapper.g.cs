using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLJobCandidateMapper
	{
		DTOJobCandidate MapModelToDTO(
			int jobCandidateID,
			ApiJobCandidateRequestModel model);

		ApiJobCandidateResponseModel MapDTOToModel(
			DTOJobCandidate dtoJobCandidate);

		List<ApiJobCandidateResponseModel> MapDTOToModel(
			List<DTOJobCandidate> dtos);
	}
}

/*<Codenesium>
    <Hash>3fd78ba2f5298daf4c3667d00eb41a92</Hash>
</Codenesium>*/