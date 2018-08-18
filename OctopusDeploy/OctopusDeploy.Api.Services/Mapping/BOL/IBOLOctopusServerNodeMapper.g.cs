using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLOctopusServerNodeMapper
	{
		BOOctopusServerNode MapModelToBO(
			string id,
			ApiOctopusServerNodeRequestModel model);

		ApiOctopusServerNodeResponseModel MapBOToModel(
			BOOctopusServerNode boOctopusServerNode);

		List<ApiOctopusServerNodeResponseModel> MapBOToModel(
			List<BOOctopusServerNode> items);
	}
}

/*<Codenesium>
    <Hash>3a44f4e9472f2917bb75db62076444c8</Hash>
</Codenesium>*/