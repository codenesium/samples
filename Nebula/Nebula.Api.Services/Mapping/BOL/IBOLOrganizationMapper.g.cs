using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>0065f5dd43bb13f9dd0a2401fdafb893</Hash>
</Codenesium>*/