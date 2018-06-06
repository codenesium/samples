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
			List<BORate> items);
	}
}

/*<Codenesium>
    <Hash>c1572dac4d9cda128350183de8b62c89</Hash>
</Codenesium>*/