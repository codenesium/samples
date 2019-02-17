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
    <Hash>3db1c0576661d13487a4340e763080eb</Hash>
</Codenesium>*/