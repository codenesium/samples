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
			ApiAirlineServerRequestModel model);

		ApiAirlineServerResponseModel MapBOToModel(
			BOAirline boAirline);

		List<ApiAirlineServerResponseModel> MapBOToModel(
			List<BOAirline> items);
	}
}

/*<Codenesium>
    <Hash>71654af89c6063b1955c350be5d99b03</Hash>
</Codenesium>*/