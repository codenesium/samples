using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLStateMapper
	{
		BOState MapModelToBO(
			int id,
			ApiStateRequestModel model);

		ApiStateResponseModel MapBOToModel(
			BOState boState);

		List<ApiStateResponseModel> MapBOToModel(
			List<BOState> items);
	}
}

/*<Codenesium>
    <Hash>82bfc3ea8bd67ffff2e85c97456fcabc</Hash>
</Codenesium>*/