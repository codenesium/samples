using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractDALProvinceMapper
	{
		public virtual Province MapModelToEntity(
			int id,
			ApiProvinceServerRequestModel model
			)
		{
			Province item = new Province();
			item.SetProperties(
				id,
				model.CountryId,
				model.Name);
			return item;
		}

		public virtual ApiProvinceServerResponseModel MapEntityToModel(
			Province item)
		{
			var model = new ApiProvinceServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CountryId,
			                    item.Name);
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

		public virtual List<ApiProvinceServerResponseModel> MapEntityToModel(
			List<Province> items)
		{
			List<ApiProvinceServerResponseModel> response = new List<ApiProvinceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b718de42d3ad782ff54182decac2ce80</Hash>
</Codenesium>*/