using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLProjectMapper
	{
		BOProject MapModelToBO(
			string id,
			ApiProjectRequestModel model);

		ApiProjectResponseModel MapBOToModel(
			BOProject boProject);

		List<ApiProjectResponseModel> MapBOToModel(
			List<BOProject> items);
	}
}

/*<Codenesium>
    <Hash>91c2d4d6cb8932ee064d4e2135ea802c</Hash>
</Codenesium>*/