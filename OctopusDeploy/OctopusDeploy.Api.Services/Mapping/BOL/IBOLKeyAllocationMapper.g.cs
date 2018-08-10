using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLKeyAllocationMapper
	{
		BOKeyAllocation MapModelToBO(
			string collectionName,
			ApiKeyAllocationRequestModel model);

		ApiKeyAllocationResponseModel MapBOToModel(
			BOKeyAllocation boKeyAllocation);

		List<ApiKeyAllocationResponseModel> MapBOToModel(
			List<BOKeyAllocation> items);
	}
}

/*<Codenesium>
    <Hash>93e125ace849dee3ee9fd0875e023f70</Hash>
</Codenesium>*/