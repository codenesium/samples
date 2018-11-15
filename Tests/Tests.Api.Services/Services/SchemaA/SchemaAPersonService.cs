using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaAPersonService : AbstractSchemaAPersonService, ISchemaAPersonService
	{
		public SchemaAPersonService(
			ILogger<ISchemaAPersonRepository> logger,
			ISchemaAPersonRepository schemaAPersonRepository,
			IApiSchemaAPersonServerRequestModelValidator schemaAPersonModelValidator,
			IBOLSchemaAPersonMapper bolSchemaAPersonMapper,
			IDALSchemaAPersonMapper dalSchemaAPersonMapper)
			: base(logger,
			       schemaAPersonRepository,
			       schemaAPersonModelValidator,
			       bolSchemaAPersonMapper,
			       dalSchemaAPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a87c28c2ce1d3ec9f7a3d9f55017ba39</Hash>
</Codenesium>*/