using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLSpaceMapper
	{
		BOSpace MapModelToBO(
			int id,
			ApiSpaceRequestModel model);

		ApiSpaceResponseModel MapBOToModel(
			BOSpace boSpace);

		List<ApiSpaceResponseModel> MapBOToModel(
			List<BOSpace> items);
	}
}

/*<Codenesium>
    <Hash>31c1bdc10e731a0a1984f28c1252afb7</Hash>
</Codenesium>*/