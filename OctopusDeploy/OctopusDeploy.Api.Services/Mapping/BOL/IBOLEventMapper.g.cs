using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLEventMapper
	{
		BOEvent MapModelToBO(
			string id,
			ApiEventRequestModel model);

		ApiEventResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>a7ae2e920cf747b166e8e8c31d1dc8cf</Hash>
</Codenesium>*/