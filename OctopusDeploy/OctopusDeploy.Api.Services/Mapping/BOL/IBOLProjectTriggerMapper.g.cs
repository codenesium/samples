using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLProjectTriggerMapper
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
    <Hash>fe24ddca34764ac3e470a0a62e18925d</Hash>
</Codenesium>*/