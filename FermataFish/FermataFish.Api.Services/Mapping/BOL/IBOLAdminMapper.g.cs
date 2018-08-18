using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLAdminMapper
	{
		BOAdmin MapModelToBO(
			int id,
			ApiAdminRequestModel model);

		ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>a663f1596b9fc7116173cc95ca9a51d8</Hash>
</Codenesium>*/