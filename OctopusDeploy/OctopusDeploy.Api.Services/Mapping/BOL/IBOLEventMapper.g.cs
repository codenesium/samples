using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLEventMapper
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
    <Hash>bc2d189c7b8c0b501d061c64b3ae4c94</Hash>
</Codenesium>*/