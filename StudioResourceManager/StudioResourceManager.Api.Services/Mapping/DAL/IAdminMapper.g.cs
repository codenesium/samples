using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALAdminMapper
	{
		Admin MapModelToEntity(
			int id,
			ApiAdminServerRequestModel model);

		ApiAdminServerResponseModel MapEntityToModel(
			Admin item);

		List<ApiAdminServerResponseModel> MapEntityToModel(
			List<Admin> items);
	}
}

/*<Codenesium>
    <Hash>806b37eae74cd25243795f333b766e74</Hash>
</Codenesium>*/