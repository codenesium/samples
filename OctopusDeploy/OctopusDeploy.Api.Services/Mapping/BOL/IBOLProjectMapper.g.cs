using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLProjectMapper
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
    <Hash>d960e91d214bbc99cb360183e64bd4f4</Hash>
</Codenesium>*/