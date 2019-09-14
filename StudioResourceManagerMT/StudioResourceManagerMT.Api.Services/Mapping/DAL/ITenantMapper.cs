using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALTenantMapper
	{
		Tenant MapModelToEntity(
			int id,
			ApiTenantServerRequestModel model);

		ApiTenantServerResponseModel MapEntityToModel(
			Tenant item);

		List<ApiTenantServerResponseModel> MapEntityToModel(
			List<Tenant> items);
	}
}

/*<Codenesium>
    <Hash>7a8be9920ec5026770b9eba1e43d5484</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/