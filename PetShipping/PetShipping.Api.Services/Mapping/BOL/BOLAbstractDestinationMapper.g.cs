using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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

			model.SetProperties(boDestination.CountryId, boDestination.Id, boDestination.Name, boDestination.Order);

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
    <Hash>bbcf572bf892f210a53ad134f0abb242</Hash>
</Codenesium>*/