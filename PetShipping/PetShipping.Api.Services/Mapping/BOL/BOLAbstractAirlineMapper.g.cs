using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractAirlineMapper
	{
		public virtual BOAirline MapModelToBO(
			int id,
			ApiAirlineRequestModel model
			)
		{
			BOAirline BOAirline = new BOAirline();

			BOAirline.SetProperties(
				id,
				model.Name);
			return BOAirline;
		}

		public virtual ApiAirlineResponseModel MapBOToModel(
			BOAirline BOAirline)
		{
			if (BOAirline == null)
			{
				return null;
			}

			var model = new ApiAirlineResponseModel();

			model.SetProperties(BOAirline.Id, BOAirline.Name);

			return model;
		}

		public virtual List<ApiAirlineResponseModel> MapBOToModel(
			List<BOAirline> BOs)
		{
			List<ApiAirlineResponseModel> response = new List<ApiAirlineResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2c3403e2bd8ee8941f4a67ac3a0ccaaa</Hash>
</Codenesium>*/