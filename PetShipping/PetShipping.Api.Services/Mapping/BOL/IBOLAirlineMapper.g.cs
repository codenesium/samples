using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLAirlineMapper
	{
		BOAirline MapModelToBO(
			int id,
			ApiAirlineRequestModel model);

		ApiAirlineResponseModel MapBOToModel(
			BOAirline boAirline);

		List<ApiAirlineResponseModel> MapBOToModel(
			List<BOAirline> items);
	}
}

/*<Codenesium>
    <Hash>e8b001548efc021302d2902802f52165</Hash>
</Codenesium>*/