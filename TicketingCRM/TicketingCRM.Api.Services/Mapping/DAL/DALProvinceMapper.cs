using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALProvinceMapper : IDALProvinceMapper
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
    <Hash>b2fedfbfa51bd96856ede3a04f380996</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/