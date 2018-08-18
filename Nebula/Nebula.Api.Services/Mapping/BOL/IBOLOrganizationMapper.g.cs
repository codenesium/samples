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
    <Hash>69337ec30fd1023bc3321e76aff491d8</Hash>
</Codenesium>*/