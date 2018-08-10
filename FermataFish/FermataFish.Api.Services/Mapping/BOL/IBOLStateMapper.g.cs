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
    <Hash>eeb5d8994f6ad8705c9f8faa157038a9</Hash>
</Codenesium>*/