using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALPetMapper : IDALPetMapper
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
				model.Price);
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
			                    item.Price);
			if (item.BreedIdNavigation != null)
			{
				var breedIdModel = new ApiBreedServerResponseModel();
				breedIdModel.SetProperties(
					item.BreedIdNavigation.Id,
					item.BreedIdNavigation.Name,
					item.BreedIdNavigation.SpeciesId);

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
    <Hash>a0ad472a08986bedca1cd319c30e9bf4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/