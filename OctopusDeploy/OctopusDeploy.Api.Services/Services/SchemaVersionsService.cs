using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class SchemaVersionsService : AbstractSchemaVersionsService, ISchemaVersionsService
	{
		public SchemaVersionsService(
			ILogger<ISchemaVersionsRepository> logger,
			ISchemaVersionsRepository schemaVersionsRepository,
			IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator,
			IBOLSchemaVersionsMapper bolschemaVersionsMapper,
			IDALSchemaVersionsMapper dalschemaVersionsMapper
			)
			: base(logger,
			       schemaVersionsRepository,
			       schemaVersionsModelValidator,
			       bolschemaVersionsMapper,
			       dalschemaVersionsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e5363c87d822ad63ebc7897cd4493f58</Hash>
</Codenesium>*/