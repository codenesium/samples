using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLMutexMapper
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
    <Hash>bfc5ed8eee6a13a8fbc35867d06b5490</Hash>
</Codenesium>*/