using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLSchemaVersionsMapper
	{
		BOSchemaVersions MapModelToBO(
			int id,
			ApiSchemaVersionsRequestModel model);

		ApiSchemaVersionsResponseModel MapBOToModel(
			BOSchemaVersions boSchemaVersions);

		List<ApiSchemaVersionsResponseModel> MapBOToModel(
			List<BOSchemaVersions> items);
	}
}

/*<Codenesium>
    <Hash>26cc5676dae833af5231b0583c945353</Hash>
</Codenesium>*/