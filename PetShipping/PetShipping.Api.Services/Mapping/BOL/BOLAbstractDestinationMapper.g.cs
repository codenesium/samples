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
			BODestination BODestination = new BODestination();

			BODestination.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
			return BODestination;
		}

		public virtual ApiDestinationResponseModel MapBOToModel(
			BODestination BODestination)
		{
			if (BODestination == null)
			{
				return null;
			}

			var model = new ApiDestinationResponseModel();

			model.SetProperties(BODestination.CountryId, BODestination.Id, BODestination.Name, BODestination.Order);

			return model;
		}

		public virtual List<ApiDestinationResponseModel> MapBOToModel(
			List<BODestination> BOs)
		{
			List<ApiDestinationResponseModel> response = new List<ApiDestinationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>56758499ef7338202208c134c9116266</Hash>
</Codenesium>*/