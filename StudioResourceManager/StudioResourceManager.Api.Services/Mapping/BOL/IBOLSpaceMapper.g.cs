using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>9058529772180b50852774153a3b3929</Hash>
</Codenesium>*/