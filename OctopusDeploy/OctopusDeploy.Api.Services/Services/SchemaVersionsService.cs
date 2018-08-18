using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>59eb9f7ebf9d1764f734e606dbab8043</Hash>
</Codenesium>*/