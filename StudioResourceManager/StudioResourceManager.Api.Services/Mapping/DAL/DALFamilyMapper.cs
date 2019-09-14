using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALFamilyMapper : IDALFamilyMapper
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
    <Hash>87ee5061820a272eaf53b96b339c9879</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/