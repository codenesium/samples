using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractCityMapper
	{
		public virtual BOCity MapModelToBO(
			int id,
			ApiCityServerRequestModel model
			)
		{
			BOCity boCity = new BOCity();
			boCity.SetProperties(
				id,
				model.Name,
				model.ProvinceId);
			return boCity;
		}

		public virtual ApiCityServerResponseModel MapBOToModel(
			BOCity boCity)
		{
			var model = new ApiCityServerResponseModel();

			model.SetProperties(boCity.Id, boCity.Name, boCity.ProvinceId);

			return model;
		}

		public virtual List<ApiCityServerResponseModel> MapBOToModel(
			List<BOCity> items)
		{
			List<ApiCityServerResponseModel> response = new List<ApiCityServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2a688a9bccbd6fb6fb41d3dda594a858</Hash>
</Codenesium>*/