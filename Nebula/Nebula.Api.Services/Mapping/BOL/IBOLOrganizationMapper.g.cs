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
			ApiOrganizationServerRequestModel model);

		ApiOrganizationServerResponseModel MapBOToModel(
			BOOrganization boOrganization);

		List<ApiOrganizationServerResponseModel> MapBOToModel(
			List<BOOrganization> items);
	}
}

/*<Codenesium>
    <Hash>5f2a7ff171b35c293abeec52ea6b647f</Hash>
</Codenesium>*/