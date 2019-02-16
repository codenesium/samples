using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALPetMapper
	{
		public virtual Pet MapModelToEntity(
			int id,
			ApiPetServerRequestModel model
			)
		{
			Pet item = new Pet();
			item.SetProperties(
				id,
				model.AcquiredDate,
				model.BreedId,
				model.Description,
				model.PenId,
				model.Price,
				model.SpeciesId);
			return item;
		}

		public virtual ApiPetServerResponseModel MapEntityToModel(
			Pet item)
		{
			var model = new ApiPetServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AcquiredDate,
			                    item.BreedId,
			                    item.Description,
			                    item.PenId,
			                    item.Price,
			                    item.SpeciesId);
			if (item.BreedIdNavigation != null)
			{
				var breedIdModel = new ApiBreedServerResponseModel();
				breedIdModel.SetProperties(
					item.BreedIdNavigation.Id,
					item.BreedIdNavigation.Name);

				model.SetBreedIdNavigation(breedIdModel);
			}

			if (item.PenIdNavigation != null)
			{
				var penIdModel = new ApiPenServerResponseModel();
				penIdModel.SetProperties(
					item.PenIdNavigation.Id,
					item.PenIdNavigation.Name);

				model.SetPenIdNavigation(penIdModel);
			}

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

		public virtual List<ApiPetServerResponseModel> MapEntityToModel(
			List<Pet> items)
		{
			List<ApiPetServerResponseModel> response = new List<ApiPetServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cef3b4d245c0ceb6cb4d2d4f103d1bc6</Hash>
</Codenesium>*/