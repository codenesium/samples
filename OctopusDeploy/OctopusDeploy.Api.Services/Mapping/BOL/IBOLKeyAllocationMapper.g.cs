using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLKeyAllocationMapper
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
    <Hash>33184c98c7753821c5f9b8dab26eb358</Hash>
</Codenesium>*/