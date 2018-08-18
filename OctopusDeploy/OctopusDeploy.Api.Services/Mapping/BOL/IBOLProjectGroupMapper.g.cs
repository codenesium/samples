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
    <Hash>1ba021ed8f626ab38222bca2ec7c7553</Hash>
</Codenesium>*/