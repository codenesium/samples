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
			ApiRateRequestModel model);

		ApiRateResponseModel MapBOToModel(
			BORate boRate);

		List<ApiRateResponseModel> MapBOToModel(
			List<BORate> items);
	}
}

/*<Codenesium>
    <Hash>6f424fc5a4d2624939423832bfcdac35</Hash>
</Codenesium>*/