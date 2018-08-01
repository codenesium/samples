using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLOctopusServerNodeMapper
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
    <Hash>f3cccb556c39dfdb48cc9599510eee70</Hash>
</Codenesium>*/