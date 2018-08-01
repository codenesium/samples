using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLOrganizationMapper
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
    <Hash>e4231126231641b5050514ddf2ea3eeb</Hash>
</Codenesium>*/