using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>7403bcdaa7ec11fb746221f42fe5c06e</Hash>
</Codenesium>*/