using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.BreedId,
				model.ClientId,
				model.Name,
				model.Weight);
			return item;
		}

		public virtual ApiPetServerResponseModel MapEntityToModel(
			Pet item)
		{
			var model = new ApiPetServerResponseModel();

			model.SetProperties(item.Id,
			                    item.BreedId,
			                    item.ClientId,
			                    item.Name,
			                    item.Weight);
			if (item.BreedIdNavigation != null)
			{
				var breedIdModel = new ApiBreedServerResponseModel();
				breedIdModel.SetProperties(
					item.BreedIdNavigation.Id,
					item.BreedIdNavigation.Name,
					item.BreedIdNavigation.SpeciesId);

				model.SetBreedIdNavigation(breedIdModel);
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
    <Hash>7f43cb855dc7dfd97f4313c555cfe6a3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/