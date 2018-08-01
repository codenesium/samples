using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLAirlineMapper
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
    <Hash>d8601e8e3400365c7177461dcf2b3f54</Hash>
</Codenesium>*/