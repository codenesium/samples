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
    <Hash>4b07d1c428a609815a16e17426e606df</Hash>
</Codenesium>*/