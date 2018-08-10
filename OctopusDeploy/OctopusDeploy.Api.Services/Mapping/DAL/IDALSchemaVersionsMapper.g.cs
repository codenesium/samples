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
    <Hash>10ea01c0c981ade4b493dade6029e663</Hash>
</Codenesium>*/