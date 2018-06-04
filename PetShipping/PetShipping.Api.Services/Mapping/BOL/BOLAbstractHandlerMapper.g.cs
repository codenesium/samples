using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerMapper
	{
		public virtual BOHandler MapModelToBO(
			int id,
			ApiHandlerRequestModel model
			)
		{
			BOHandler BOHandler = new BOHandler();

			BOHandler.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return BOHandler;
		}

		public virtual ApiHandlerResponseModel MapBOToModel(
			BOHandler BOHandler)
		{
			if (BOHandler == null)
			{
				return null;
			}

			var model = new ApiHandlerResponseModel();

			model.SetProperties(BOHandler.CountryId, BOHandler.Email, BOHandler.FirstName, BOHandler.Id, BOHandler.LastName, BOHandler.Phone);

			return model;
		}

		public virtual List<ApiHandlerResponseModel> MapBOToModel(
			List<BOHandler> BOs)
		{
			List<ApiHandlerResponseModel> response = new List<ApiHandlerResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>825f4d7bae7193b1521e4392996eb3ab</Hash>
</Codenesium>*/