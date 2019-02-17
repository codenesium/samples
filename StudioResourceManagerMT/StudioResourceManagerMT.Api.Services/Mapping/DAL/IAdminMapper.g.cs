using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>954a6d81926e28d9ee2bd4c735737359</Hash>
</Codenesium>*/