using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAirlineMapper
	{
		public virtual DTOAirline MapModelToDTO(
			int id,
			ApiAirlineRequestModel model
			)
		{
			DTOAirline dtoAirline = new DTOAirline();

			dtoAirline.SetProperties(
				id,
				model.Name);
			return dtoAirline;
		}

		public virtual ApiAirlineResponseModel MapDTOToModel(
			DTOAirline dtoAirline)
		{
			if (dtoAirline == null)
			{
				return null;
			}

			var model = new ApiAirlineResponseModel();

			model.SetProperties(dtoAirline.Id, dtoAirline.Name);

			return model;
		}

		public virtual List<ApiAirlineResponseModel> MapDTOToModel(
			List<DTOAirline> dtos)
		{
			List<ApiAirlineResponseModel> response = new List<ApiAirlineResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>10d517e6088d6398134907be1bfebbcf</Hash>
</Codenesium>*/