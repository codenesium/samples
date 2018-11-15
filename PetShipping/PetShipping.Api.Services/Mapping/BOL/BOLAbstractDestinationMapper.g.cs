using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractDestinationMapper
	{
		public virtual BODestination MapModelToBO(
			int id,
			ApiDestinationServerRequestModel model
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

		public virtual ApiDestinationServerResponseModel MapBOToModel(
			BODestination boDestination)
		{
			var model = new ApiDestinationServerResponseModel();

			model.SetProperties(boDestination.Id, boDestination.CountryId, boDestination.Name, boDestination.Order);

			return model;
		}

		public virtual List<ApiDestinationServerResponseModel> MapBOToModel(
			List<BODestination> items)
		{
			List<ApiDestinationServerResponseModel> response = new List<ApiDestinationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2cf5c322a0140123e80c8b5708e86922</Hash>
</Codenesium>*/