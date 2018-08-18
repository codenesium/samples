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
    <Hash>2098ada85f55c937519f387dcf51466a</Hash>
</Codenesium>*/