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
			List<BOAirline> bos);
	}
}

/*<Codenesium>
    <Hash>d5e82cb53d3df40fc473344815665a17</Hash>
</Codenesium>*/