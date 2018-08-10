using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLProjectGroupMapper
	{
		BOProjectGroup MapModelToBO(
			string id,
			ApiProjectGroupRequestModel model);

		ApiProjectGroupResponseModel MapBOToModel(
			BOProjectGroup boProjectGroup);

		List<ApiProjectGroupResponseModel> MapBOToModel(
			List<BOProjectGroup> items);
	}
}

/*<Codenesium>
    <Hash>3d909d992995c93a45ed729463f11f1b</Hash>
</Codenesium>*/