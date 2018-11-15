using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLEventStatuMapper
	{
		BOEventStatu MapModelToBO(
			int id,
			ApiEventStatuServerRequestModel model);

		ApiEventStatuServerResponseModel MapBOToModel(
			BOEventStatu boEventStatu);

		List<ApiEventStatuServerResponseModel> MapBOToModel(
			List<BOEventStatu> items);
	}
}

/*<Codenesium>
    <Hash>ab993c546c1619683970022a6b0b0fb2</Hash>
</Codenesium>*/