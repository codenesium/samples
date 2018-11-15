using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractSpeciesMapper
	{
		public virtual BOSpecies MapModelToBO(
			int id,
			ApiSpeciesServerRequestModel model
			)
		{
			BOSpecies boSpecies = new BOSpecies();
			boSpecies.SetProperties(
				id,
				model.Name);
			return boSpecies;
		}

		public virtual ApiSpeciesServerResponseModel MapBOToModel(
			BOSpecies boSpecies)
		{
			var model = new ApiSpeciesServerResponseModel();

			model.SetProperties(boSpecies.Id, boSpecies.Name);

			return model;
		}

		public virtual List<ApiSpeciesServerResponseModel> MapBOToModel(
			List<BOSpecies> items)
		{
			List<ApiSpeciesServerResponseModel> response = new List<ApiSpeciesServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>60ee143591b60cd087034b58e20d4a12</Hash>
</Codenesium>*/