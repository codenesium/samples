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
    <Hash>c9e2ca8fa2fdaada34365224dfc415d3</Hash>
</Codenesium>*/