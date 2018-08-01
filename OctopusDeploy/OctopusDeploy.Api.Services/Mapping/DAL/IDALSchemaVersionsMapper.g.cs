using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALSchemaVersionsMapper
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
    <Hash>c8396aec1ef74c61844d1e7221ad58f7</Hash>
</Codenesium>*/