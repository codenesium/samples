using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>e786cd7dc16a7360d3221da4c4059bf9</Hash>
</Codenesium>*/