using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>cd38ccefa89bfbb8f0fa60bd90664a59</Hash>
</Codenesium>*/