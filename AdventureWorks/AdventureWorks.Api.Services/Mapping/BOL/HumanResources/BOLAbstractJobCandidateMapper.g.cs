using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractJobCandidateMapper
	{
		public virtual BOJobCandidate MapModelToBO(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel model
			)
		{
			BOJobCandidate boJobCandidate = new BOJobCandidate();
			boJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
			return boJobCandidate;
		}

		public virtual ApiJobCandidateServerResponseModel MapBOToModel(
			BOJobCandidate boJobCandidate)
		{
			var model = new ApiJobCandidateServerResponseModel();

			model.SetProperties(boJobCandidate.JobCandidateID, boJobCandidate.BusinessEntityID, boJobCandidate.ModifiedDate, boJobCandidate.Resume);

			return model;
		}

		public virtual List<ApiJobCandidateServerResponseModel> MapBOToModel(
			List<BOJobCandidate> items)
		{
			List<ApiJobCandidateServerResponseModel> response = new List<ApiJobCandidateServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e7830aefea132fdffe1f14fa80b5b66e</Hash>
</Codenesium>*/