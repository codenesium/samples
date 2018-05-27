using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLHandlerMapper
	{
		public virtual DTOHandler MapModelToDTO(
			int id,
			ApiHandlerRequestModel model
			)
		{
			DTOHandler dtoHandler = new DTOHandler();

			dtoHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return dtoHandler;
		}

		public virtual ApiHandlerResponseModel MapDTOToModel(
			DTOHandler dtoHandler)
		{
			if (dtoHandler == null)
			{
				return null;
			}

			var model = new ApiHandlerResponseModel();

			model.SetProperties(dtoHandler.CountryId, dtoHandler.Email, dtoHandler.FirstName, dtoHandler.Id, dtoHandler.LastName, dtoHandler.Phone);

			return model;
		}

		public virtual List<ApiHandlerResponseModel> MapDTOToModel(
			List<DTOHandler> dtos)
		{
			List<ApiHandlerResponseModel> response = new List<ApiHandlerResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>86d8741d7f1508e0cbd526fbe5abba5d</Hash>
</Codenesium>*/