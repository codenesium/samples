using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractDALFamilyMapper
	{
		public virtual Family MapModelToEntity(
			int id,
			ApiFamilyServerRequestModel model
			)
		{
			Family item = new Family();
			item.SetProperties(
				id,
				model.Notes,
				model.PrimaryContactEmail,
				model.PrimaryContactFirstName,
				model.PrimaryContactLastName,
				model.PrimaryContactPhone);
			return item;
		}

		public virtual ApiFamilyServerResponseModel MapEntityToModel(
			Family item)
		{
			var model = new ApiFamilyServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Notes,
			                    item.PrimaryContactEmail,
			                    item.PrimaryContactFirstName,
			                    item.PrimaryContactLastName,
			                    item.PrimaryContactPhone);

			return model;
		}

		public virtual List<ApiFamilyServerResponseModel> MapEntityToModel(
			List<Family> items)
		{
			List<ApiFamilyServerResponseModel> response = new List<ApiFamilyServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b4e111737b286afd42c260f7927f4657</Hash>
</Codenesium>*/