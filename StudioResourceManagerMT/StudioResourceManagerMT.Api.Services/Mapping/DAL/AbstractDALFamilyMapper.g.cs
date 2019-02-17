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
				model.Note,
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
			                    item.Note,
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
    <Hash>aaf3250b10604260c1c1ba7a94eec823</Hash>
</Codenesium>*/