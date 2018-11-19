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
			ApiAdminServerRequestModel model);

		ApiAdminServerResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminServerResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>78bece7576cfd47c97c24ff08b016843</Hash>
</Codenesium>*/