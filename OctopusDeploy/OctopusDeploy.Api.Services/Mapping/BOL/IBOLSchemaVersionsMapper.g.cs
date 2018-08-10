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
    <Hash>4ccdd024291b5b9c604465296f51f115</Hash>
</Codenesium>*/