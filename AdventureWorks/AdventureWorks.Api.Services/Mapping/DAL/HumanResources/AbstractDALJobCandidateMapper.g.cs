using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALJobCandidateMapper
	{
		public virtual JobCandidate MapModelToEntity(
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

		public virtual ApiJobCandidateServerResponseModel MapEntityToModel(
			JobCandidate item)
		{
			var model = new ApiJobCandidateServerResponseModel();

			model.SetProperties(item.JobCandidateID,
			                    item.BusinessEntityID,
			                    item.ModifiedDate,
			                    item.Resume);

			return model;
		}

		public virtual List<ApiJobCandidateServerResponseModel> MapEntityToModel(
			List<JobCandidate> items)
		{
			List<ApiJobCandidateServerResponseModel> response = new List<ApiJobCandidateServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a08ad92ae2648031faad75a46ec29d82</Hash>
</Codenesium>*/