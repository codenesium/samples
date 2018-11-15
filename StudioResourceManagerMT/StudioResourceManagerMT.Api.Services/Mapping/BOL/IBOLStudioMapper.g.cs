using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLStudioMapper
	{
		BOStudio MapModelToBO(
			int id,
			ApiStudioServerRequestModel model);

		ApiStudioServerResponseModel MapBOToModel(
			BOStudio boStudio);

		List<ApiStudioServerResponseModel> MapBOToModel(
			List<BOStudio> items);
	}
}

/*<Codenesium>
    <Hash>d6079ee7848f9b1e2474dec17299a8af</Hash>
</Codenesium>*/