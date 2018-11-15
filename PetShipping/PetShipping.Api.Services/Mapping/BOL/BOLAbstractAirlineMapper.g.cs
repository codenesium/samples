using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractAirlineMapper
	{
		public virtual BOAirline MapModelToBO(
			int id,
			ApiAirlineServerRequestModel model
			)
		{
			BOAirline boAirline = new BOAirline();
			boAirline.SetProperties(
				id,
				model.Name);
			return boAirline;
		}

		public virtual ApiAirlineServerResponseModel MapBOToModel(
			BOAirline boAirline)
		{
			var model = new ApiAirlineServerResponseModel();

			model.SetProperties(boAirline.Id, boAirline.Name);

			return model;
		}

		public virtual List<ApiAirlineServerResponseModel> MapBOToModel(
			List<BOAirline> items)
		{
			List<ApiAirlineServerResponseModel> response = new List<ApiAirlineServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>22ef548699e616ed58ac4c2829166f31</Hash>
</Codenesium>*/