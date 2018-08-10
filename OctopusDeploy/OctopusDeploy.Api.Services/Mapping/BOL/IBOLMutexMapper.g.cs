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
    <Hash>de3574f3fcce36f404c6a11033e188cf</Hash>
</Codenesium>*/