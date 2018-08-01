using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLProjectGroupMapper
	{
		BOProjectGroup MapModelToBO(
			string id,
			ApiProjectGroupRequestModel model);

		ApiProjectGroupResponseModel MapBOToModel(
			BOProjectGroup boProjectGroup);

		List<ApiProjectGroupResponseModel> MapBOToModel(
			List<BOProjectGroup> items);
	}
}

/*<Codenesium>
    <Hash>2e734b01bc4d2aefb0a03ce90b817e87</Hash>
</Codenesium>*/