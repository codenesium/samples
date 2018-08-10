using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLOrganizationMapper
	{
		BOOrganization MapModelToBO(
			int id,
			ApiOrganizationRequestModel model);

		ApiOrganizationResponseModel MapBOToModel(
			BOOrganization boOrganization);

		List<ApiOrganizationResponseModel> MapBOToModel(
			List<BOOrganization> items);
	}
}

/*<Codenesium>
    <Hash>a0e105c4113235baf1071c341464adb3</Hash>
</Codenesium>*/