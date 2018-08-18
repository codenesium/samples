using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLSchemaVersionsMapper
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
    <Hash>27ce1e831432535517b6d183ed8638a4</Hash>
</Codenesium>*/