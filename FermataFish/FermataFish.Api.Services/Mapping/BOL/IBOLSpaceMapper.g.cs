using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLSpaceMapper
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
    <Hash>e3e34b696ce861af40ef1d14208d9379</Hash>
</Codenesium>*/