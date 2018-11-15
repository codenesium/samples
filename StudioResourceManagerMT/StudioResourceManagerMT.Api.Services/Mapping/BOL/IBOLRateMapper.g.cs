using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>4d91c78941f272d5f46a01c636bf18ce</Hash>
</Codenesium>*/