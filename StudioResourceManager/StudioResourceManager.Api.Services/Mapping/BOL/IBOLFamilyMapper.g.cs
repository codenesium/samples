using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLFamilyMapper
	{
		BOFamily MapModelToBO(
			int id,
			ApiFamilyRequestModel model);

		ApiFamilyResponseModel MapBOToModel(
			BOFamily boFamily);

		List<ApiFamilyResponseModel> MapBOToModel(
			List<BOFamily> items);
	}
}

/*<Codenesium>
    <Hash>bca31f632eba32d2effe8a796f347e9c</Hash>
</Codenesium>*/