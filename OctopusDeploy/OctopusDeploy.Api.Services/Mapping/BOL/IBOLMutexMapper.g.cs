using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLMutexMapper
	{
		BOMutex MapModelToBO(
			string id,
			ApiMutexRequestModel model);

		ApiMutexResponseModel MapBOToModel(
			BOMutex boMutex);

		List<ApiMutexResponseModel> MapBOToModel(
			List<BOMutex> items);
	}
}

/*<Codenesium>
    <Hash>e72012f77b89fca0125d366292e43975</Hash>
</Codenesium>*/