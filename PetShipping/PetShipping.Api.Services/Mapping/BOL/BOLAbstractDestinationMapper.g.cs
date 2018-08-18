using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractDestinationMapper
	{
		public virtual BODestination MapModelToBO(
			int id,
			ApiDestinationRequestModel model
			)
		{
			BODestination boDestination = new BODestination();
			boDestination.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
			return boDestination;
		}

		public virtual ApiDestinationResponseModel MapBOToModel(
			BODestination boDestination)
		{
			var model = new ApiDestinationResponseModel();

			model.SetProperties(boDestination.Id, boDestination.CountryId, boDestination.Name, boDestination.Order);

			return model;
		}

		public virtual List<ApiDestinationResponseModel> MapBOToModel(
			List<BODestination> items)
		{
			List<ApiDestinationResponseModel> response = new List<ApiDestinationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0f709ebc67c7a5b9aaf9d196fa9b2de2</Hash>
</Codenesium>*/