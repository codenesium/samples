using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLSpaceMapper
	{
		BOSpace MapModelToBO(
			int id,
			ApiSpaceServerRequestModel model);

		ApiSpaceServerResponseModel MapBOToModel(
			BOSpace boSpace);

		List<ApiSpaceServerResponseModel> MapBOToModel(
			List<BOSpace> items);
	}
}

/*<Codenesium>
    <Hash>5046bab045f9acf3e5c07b0fd7c5e833</Hash>
</Codenesium>*/