using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDestinationMapper
	{
		public virtual DTODestination MapModelToDTO(
			int id,
			ApiDestinationRequestModel model
			)
		{
			DTODestination dtoDestination = new DTODestination();

			dtoDestination.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
			return dtoDestination;
		}

		public virtual ApiDestinationResponseModel MapDTOToModel(
			DTODestination dtoDestination)
		{
			if (dtoDestination == null)
			{
				return null;
			}

			var model = new ApiDestinationResponseModel();

			model.SetProperties(dtoDestination.CountryId, dtoDestination.Id, dtoDestination.Name, dtoDestination.Order);

			return model;
		}

		public virtual List<ApiDestinationResponseModel> MapDTOToModel(
			List<DTODestination> dtos)
		{
			List<ApiDestinationResponseModel> response = new List<ApiDestinationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1657971707f0561340c50133e5500837</Hash>
</Codenesium>*/