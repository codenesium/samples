using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALJobCandidateMapper
	{
		public virtual JobCandidate MapModelToBO(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel model
			)
		{
			JobCandidate item = new JobCandidate();
			item.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
			return item;
		}

		public virtual ApiJobCandidateServerResponseModel MapBOToModel(
			JobCandidate item)
		{
			var model = new ApiJobCandidateServerResponseModel();

			model.SetProperties(item.JobCandidateID, item.BusinessEntityID, item.ModifiedDate, item.Resume);

			return model;
		}

		public virtual List<ApiJobCandidateServerResponseModel> MapBOToModel(
			List<JobCandidate> items)
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
    <Hash>c7bf197369a77d0637a01df17d4269de</Hash>
</Codenesium>*/