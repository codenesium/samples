using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALBreedMapper : IDALBreedMapper
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
    <Hash>e9a70e8466bc87d7f941241ee069dc9c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/