using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLJobCandidateMapper
	{
		public virtual DTOJobCandidate MapModelToDTO(
			int jobCandidateID,
			ApiJobCandidateRequestModel model
			)
		{
			DTOJobCandidate dtoJobCandidate = new DTOJobCandidate();

			dtoJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
			return dtoJobCandidate;
		}

		public virtual ApiJobCandidateResponseModel MapDTOToModel(
			DTOJobCandidate dtoJobCandidate)
		{
			if (dtoJobCandidate == null)
			{
				return null;
			}

			var model = new ApiJobCandidateResponseModel();

			model.SetProperties(dtoJobCandidate.BusinessEntityID, dtoJobCandidate.JobCandidateID, dtoJobCandidate.ModifiedDate, dtoJobCandidate.Resume);

			return model;
		}

		public virtual List<ApiJobCandidateResponseModel> MapDTOToModel(
			List<DTOJobCandidate> dtos)
		{
			List<ApiJobCandidateResponseModel> response = new List<ApiJobCandidateResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e77573a55440970c0bfb30dda44c2237</Hash>
</Codenesium>*/