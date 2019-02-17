using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.Name,
				model.SpeciesId);
			return item;
		}

		public virtual ApiBreedServerResponseModel MapEntityToModel(
			Breed item)
		{
			var model = new ApiBreedServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.SpeciesId);
			if (item.SpeciesIdNavigation != null)
			{
				var speciesIdModel = new ApiSpeciesServerResponseModel();
				speciesIdModel.SetProperties(
					item.SpeciesIdNavigation.Id,
					item.SpeciesIdNavigation.Name);

				model.SetSpeciesIdNavigation(speciesIdModel);
			}

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
    <Hash>cac3861fea83989b5acc1332cd6b612e</Hash>
</Codenesium>*/