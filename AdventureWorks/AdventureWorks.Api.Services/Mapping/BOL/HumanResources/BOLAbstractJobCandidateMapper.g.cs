using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractJobCandidateMapper
	{
		public virtual BOJobCandidate MapModelToBO(
			int jobCandidateID,
			ApiJobCandidateRequestModel model
			)
		{
			BOJobCandidate BOJobCandidate = new BOJobCandidate();

			BOJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
			return BOJobCandidate;
		}

		public virtual ApiJobCandidateResponseModel MapBOToModel(
			BOJobCandidate BOJobCandidate)
		{
			if (BOJobCandidate == null)
			{
				return null;
			}

			var model = new ApiJobCandidateResponseModel();

			model.SetProperties(BOJobCandidate.BusinessEntityID, BOJobCandidate.JobCandidateID, BOJobCandidate.ModifiedDate, BOJobCandidate.Resume);

			return model;
		}

		public virtual List<ApiJobCandidateResponseModel> MapBOToModel(
			List<BOJobCandidate> BOs)
		{
			List<ApiJobCandidateResponseModel> response = new List<ApiJobCandidateResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe5d3d2a89a93ea3d66f0fd9149b3a7b</Hash>
</Codenesium>*/