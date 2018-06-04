using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLRateMapper
	{
		BORate MapModelToBO(
			int id,
			ApiRateRequestModel model);

		ApiRateResponseModel MapBOToModel(
			BORate boRate);

		List<ApiRateResponseModel> MapBOToModel(
			List<BORate> bos);
	}
}

/*<Codenesium>
    <Hash>ae418df333e930ce92e83940d2dbc054</Hash>
</Codenesium>*/