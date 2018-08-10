using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLProjectTriggerMapper
	{
		BOProjectTrigger MapModelToBO(
			string id,
			ApiProjectTriggerRequestModel model);

		ApiProjectTriggerResponseModel MapBOToModel(
			BOProjectTrigger boProjectTrigger);

		List<ApiProjectTriggerResponseModel> MapBOToModel(
			List<BOProjectTrigger> items);
	}
}

/*<Codenesium>
    <Hash>5171abbaf47e305d0dd32f056d5a02ee</Hash>
</Codenesium>*/