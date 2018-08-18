using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerMapper
	{
		public virtual BOHandler MapModelToBO(
			int id,
			ApiHandlerRequestModel model
			)
		{
			BOHandler boHandler = new BOHandler();
			boHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return boHandler;
		}

		public virtual ApiHandlerResponseModel MapBOToModel(
			BOHandler boHandler)
		{
			var model = new ApiHandlerResponseModel();

			model.SetProperties(boHandler.Id, boHandler.CountryId, boHandler.Email, boHandler.FirstName, boHandler.LastName, boHandler.Phone);

			return model;
		}

		public virtual List<ApiHandlerResponseModel> MapBOToModel(
			List<BOHandler> items)
		{
			List<ApiHandlerResponseModel> response = new List<ApiHandlerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>914d8e3484c6ebb102aa8bc35b78a20e</Hash>
</Codenesium>*/