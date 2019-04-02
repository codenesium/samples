using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>b5248b3064c0b3436fb6729dfbe64884</Hash>
</Codenesium>*/