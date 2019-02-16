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
					item.Id,
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
    <Hash>d5b15687177ed1a0ece4016ac2111186</Hash>
</Codenesium>*/