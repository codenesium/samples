using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractBreedMapper
	{
		public virtual BOBreed MapModelToBO(
			int id,
			ApiBreedServerRequestModel model
			)
		{
			BOBreed boBreed = new BOBreed();
			boBreed.SetProperties(
				id,
				model.Name);
			return boBreed;
		}

		public virtual ApiBreedServerResponseModel MapBOToModel(
			BOBreed boBreed)
		{
			var model = new ApiBreedServerResponseModel();

			model.SetProperties(boBreed.Id, boBreed.Name);

			return model;
		}

		public virtual List<ApiBreedServerResponseModel> MapBOToModel(
			List<BOBreed> items)
		{
			List<ApiBreedServerResponseModel> response = new List<ApiBreedServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5fd3a6a3a2358f35aaada93ccc223b0a</Hash>
</Codenesium>*/