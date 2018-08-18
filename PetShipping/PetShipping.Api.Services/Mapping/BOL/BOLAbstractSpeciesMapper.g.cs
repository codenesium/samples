using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractSpeciesMapper
	{
		public virtual BOSpecies MapModelToBO(
			int id,
			ApiSpeciesRequestModel model
			)
		{
			BOSpecies boSpecies = new BOSpecies();
			boSpecies.SetProperties(
				id,
				model.Name);
			return boSpecies;
		}

		public virtual ApiSpeciesResponseModel MapBOToModel(
			BOSpecies boSpecies)
		{
			var model = new ApiSpeciesResponseModel();

			model.SetProperties(boSpecies.Id, boSpecies.Name);

			return model;
		}

		public virtual List<ApiSpeciesResponseModel> MapBOToModel(
			List<BOSpecies> items)
		{
			List<ApiSpeciesResponseModel> response = new List<ApiSpeciesResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8e15eb1115b7c3172be1ef69fbd4bf3f</Hash>
</Codenesium>*/