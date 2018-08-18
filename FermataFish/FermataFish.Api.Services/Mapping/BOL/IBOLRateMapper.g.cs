using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLRateMapper
	{
		BORate MapModelToBO(
			int id,
			ApiRateRequestModel model);

		ApiRateResponseModel MapBOToModel(
			BORate boRate);

		List<ApiRateResponseModel> MapBOToModel(
			List<BORate> items);
	}
}

/*<Codenesium>
    <Hash>e1422df938cbcec88ce41ec076a67412</Hash>
</Codenesium>*/