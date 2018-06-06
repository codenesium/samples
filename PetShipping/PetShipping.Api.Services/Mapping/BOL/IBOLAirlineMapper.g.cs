using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>a4e556dae10993ae4ddd46cc1faa6056</Hash>
</Codenesium>*/