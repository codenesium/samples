using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALSchemaVersionsMapper
	{
		SchemaVersions MapBOToEF(
			BOSchemaVersions bo);

		BOSchemaVersions MapEFToBO(
			SchemaVersions efSchemaVersions);

		List<BOSchemaVersions> MapEFToBO(
			List<SchemaVersions> records);
	}
}

/*<Codenesium>
    <Hash>7e13825d32c7cc289e88674dce947e33</Hash>
</Codenesium>*/