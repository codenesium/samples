using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>3b1260a138d8ca06ec688962e8f6acec</Hash>
</Codenesium>*/