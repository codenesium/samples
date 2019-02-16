using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALSpeciesMapper
	{
		public virtual Species MapModelToEntity(
			int id,
			ApiSpeciesServerRequestModel model
			)
		{
			Species item = new Species();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiSpeciesServerResponseModel MapEntityToModel(
			Species item)
		{
			var model = new ApiSpeciesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiSpeciesServerResponseModel> MapEntityToModel(
			List<Species> items)
		{
			List<ApiSpeciesServerResponseModel> response = new List<ApiSpeciesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>917445b212d9446c946b7a89af5d2319</Hash>
</Codenesium>*/