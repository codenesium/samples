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
			if (item.BusinessEntityIDNavigation != null)
			{
				var businessEntityIDModel = new ApiEmployeeServerResponseModel();
				businessEntityIDModel.SetProperties(
					item.BusinessEntityIDNavigation.BusinessEntityID,
					item.BusinessEntityIDNavigation.BirthDate,
					item.BusinessEntityIDNavigation.CurrentFlag,
					item.BusinessEntityIDNavigation.Gender,
					item.BusinessEntityIDNavigation.HireDate,
					item.BusinessEntityIDNavigation.JobTitle,
					item.BusinessEntityIDNavigation.LoginID,
					item.BusinessEntityIDNavigation.MaritalStatu,
					item.BusinessEntityIDNavigation.ModifiedDate,
					item.BusinessEntityIDNavigation.NationalIDNumber,
					item.BusinessEntityIDNavigation.OrganizationLevel,
					item.BusinessEntityIDNavigation.Rowguid,
					item.BusinessEntityIDNavigation.SalariedFlag,
					item.BusinessEntityIDNavigation.SickLeaveHour,
					item.BusinessEntityIDNavigation.VacationHour);

				model.SetBusinessEntityIDNavigation(businessEntityIDModel);
			}

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
    <Hash>0444964127b5c7eca452357e5a907151</Hash>
</Codenesium>*/