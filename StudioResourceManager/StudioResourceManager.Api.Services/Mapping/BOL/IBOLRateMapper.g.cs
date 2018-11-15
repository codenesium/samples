using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLRateMapper
	{
		BORate MapModelToBO(
			int id,
			ApiRateServerRequestModel model);

		ApiRateServerResponseModel MapBOToModel(
			BORate boRate);

		List<ApiRateServerResponseModel> MapBOToModel(
			List<BORate> items);
	}
}

/*<Codenesium>
    <Hash>f18b0b213157811330316f73e0284bd6</Hash>
</Codenesium>*/