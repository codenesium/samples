using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALBreedMapper
	{
		public virtual Breed MapModelToEntity(
			int id,
			ApiBreedServerRequestModel model
			)
		{
			Breed item = new Breed();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiBreedServerResponseModel MapEntityToModel(
			Breed item)
		{
			var model = new ApiBreedServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiBreedServerResponseModel> MapEntityToModel(
			List<Breed> items)
		{
			List<ApiBreedServerResponseModel> response = new List<ApiBreedServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1fcbea0a090abef3175a2135f5d37970</Hash>
</Codenesium>*/