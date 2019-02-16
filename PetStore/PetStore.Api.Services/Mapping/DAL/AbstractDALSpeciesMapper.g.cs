using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>aeaaf6f530603fa140247ca916886e88</Hash>
</Codenesium>*/