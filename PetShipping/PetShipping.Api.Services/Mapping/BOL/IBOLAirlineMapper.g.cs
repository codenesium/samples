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
    <Hash>51e4b57ed3e45bec38ae886065afba44</Hash>
</Codenesium>*/