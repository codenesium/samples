using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCountryMapper
	{
		public virtual DTOCountry MapModelToDTO(
			int id,
			ApiCountryRequestModel model
			)
		{
			DTOCountry dtoCountry = new DTOCountry();

			dtoCountry.SetProperties(
				id,
				model.Name);
			return dtoCountry;
		}

		public virtual ApiCountryResponseModel MapDTOToModel(
			DTOCountry dtoCountry)
		{
			if (dtoCountry == null)
			{
				return null;
			}

			var model = new ApiCountryResponseModel();

			model.SetProperties(dtoCountry.Id, dtoCountry.Name);

			return model;
		}

		public virtual List<ApiCountryResponseModel> MapDTOToModel(
			List<DTOCountry> dtos)
		{
			List<ApiCountryResponseModel> response = new List<ApiCountryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9997f0dac3bffe89585abbc69bf934ce</Hash>
</Codenesium>*/