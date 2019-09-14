using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALOrganizationMapper
	{
		Organization MapModelToEntity(
			int id,
			ApiOrganizationServerRequestModel model);

		ApiOrganizationServerResponseModel MapEntityToModel(
			Organization item);

		List<ApiOrganizationServerResponseModel> MapEntityToModel(
			List<Organization> items);
	}
}

/*<Codenesium>
    <Hash>2663e9323bc2ad0f32cc7c4775979ab1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/