using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerMapper
	{
		public virtual BOHandler MapModelToBO(
			int id,
			ApiHandlerServerRequestModel model
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

		public virtual ApiHandlerServerResponseModel MapBOToModel(
			BOHandler boHandler)
		{
			var model = new ApiHandlerServerResponseModel();

			model.SetProperties(boHandler.Id, boHandler.CountryId, boHandler.Email, boHandler.FirstName, boHandler.LastName, boHandler.Phone);

			return model;
		}

		public virtual List<ApiHandlerServerResponseModel> MapBOToModel(
			List<BOHandler> items)
		{
			List<ApiHandlerServerResponseModel> response = new List<ApiHandlerServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4abcccad5cdd39214ee51364718c124f</Hash>
</Codenesium>*/