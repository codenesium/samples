using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class DALCityMapper : IDALCityMapper
	{
		public virtual City MapModelToEntity(
			int id,
			ApiCityServerRequestModel model
			)
		{
			City item = new City();
			item.SetProperties(
				id,
				model.Name,
				model.ProvinceId);
			return item;
		}

		public virtual ApiCityServerResponseModel MapEntityToModel(
			City item)
		{
			var model = new ApiCityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.ProvinceId);
			if (item.ProvinceIdNavigation != null)
			{
				var provinceIdModel = new ApiProvinceServerResponseModel();
				provinceIdModel.SetProperties(
					item.ProvinceIdNavigation.Id,
					item.ProvinceIdNavigation.CountryId,
					item.ProvinceIdNavigation.Name);

				model.SetProvinceIdNavigation(provinceIdModel);
			}

			return model;
		}

		public virtual List<ApiCityServerResponseModel> MapEntityToModel(
			List<City> items)
		{
			List<ApiCityServerResponseModel> response = new List<ApiCityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e0aa49e1d0bb565ce3d3b96ec0c79db1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/