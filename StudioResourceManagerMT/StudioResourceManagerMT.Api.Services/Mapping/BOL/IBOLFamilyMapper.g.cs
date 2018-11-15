using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLFamilyMapper
	{
		BOFamily MapModelToBO(
			int id,
			ApiFamilyServerRequestModel model);

		ApiFamilyServerResponseModel MapBOToModel(
			BOFamily boFamily);

		List<ApiFamilyServerResponseModel> MapBOToModel(
			List<BOFamily> items);
	}
}

/*<Codenesium>
    <Hash>b1a7bbf2ece6e82b3b1b29b9e40259bd</Hash>
</Codenesium>*/