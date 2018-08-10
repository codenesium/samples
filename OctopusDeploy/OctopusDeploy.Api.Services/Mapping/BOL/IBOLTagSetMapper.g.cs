using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLTagSetMapper
	{
		BOTagSet MapModelToBO(
			string id,
			ApiTagSetRequestModel model);

		ApiTagSetResponseModel MapBOToModel(
			BOTagSet boTagSet);

		List<ApiTagSetResponseModel> MapBOToModel(
			List<BOTagSet> items);
	}
}

/*<Codenesium>
    <Hash>ca509a55c9b33e774aef2c9439ac85ed</Hash>
</Codenesium>*/