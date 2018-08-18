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
    <Hash>412143174b24838fc3d327f103395919</Hash>
</Codenesium>*/