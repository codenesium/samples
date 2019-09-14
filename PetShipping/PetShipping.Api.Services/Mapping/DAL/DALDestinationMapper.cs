using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALDestinationMapper : IDALDestinationMapper
	{
		public virtual Destination MapModelToEntity(
			int id,
			ApiDestinationServerRequestModel model
			)
		{
			Destination item = new Destination();
			item.SetProperties(
				id,
				model.CountryId,
				model.Name,
				model.Order);
			return item;
		}

		public virtual ApiDestinationServerResponseModel MapEntityToModel(
			Destination item)
		{
			var model = new ApiDestinationServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CountryId,
			                    item.Name,
			                    item.Order);
			if (item.CountryIdNavigation != null)
			{
				var countryIdModel = new ApiCountryServerResponseModel();
				countryIdModel.SetProperties(
					item.CountryIdNavigation.Id,
					item.CountryIdNavigation.Name);

				model.SetCountryIdNavigation(countryIdModel);
			}

			return model;
		}

		public virtual List<ApiDestinationServerResponseModel> MapEntityToModel(
			List<Destination> items)
		{
			List<ApiDestinationServerResponseModel> response = new List<ApiDestinationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1939da822966350746ed6aa1617bf611</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/