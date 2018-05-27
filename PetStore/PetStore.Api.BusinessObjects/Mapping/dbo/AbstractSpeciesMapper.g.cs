using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpeciesMapper
	{
		public virtual DTOSpecies MapModelToDTO(
			int id,
			ApiSpeciesRequestModel model
			)
		{
			DTOSpecies dtoSpecies = new DTOSpecies();

			dtoSpecies.SetProperties(
				id,
				model.Name);
			return dtoSpecies;
		}

		public virtual ApiSpeciesResponseModel MapDTOToModel(
			DTOSpecies dtoSpecies)
		{
			if (dtoSpecies == null)
			{
				return null;
			}

			var model = new ApiSpeciesResponseModel();

			model.SetProperties(dtoSpecies.Id, dtoSpecies.Name);

			return model;
		}

		public virtual List<ApiSpeciesResponseModel> MapDTOToModel(
			List<DTOSpecies> dtos)
		{
			List<ApiSpeciesResponseModel> response = new List<ApiSpeciesResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>53fc8180575ecf38b2b39e1580589b8a</Hash>
</Codenesium>*/