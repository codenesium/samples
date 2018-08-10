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
    <Hash>5ab690ddc86eb960cbf1c34793798765</Hash>
</Codenesium>*/