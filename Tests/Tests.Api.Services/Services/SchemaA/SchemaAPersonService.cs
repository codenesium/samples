using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaAPersonService : AbstractSchemaAPersonService, ISchemaAPersonService
	{
		public SchemaAPersonService(
			ILogger<ISchemaAPersonRepository> logger,
			IMediator mediator,
			ISchemaAPersonRepository schemaAPersonRepository,
			IApiSchemaAPersonServerRequestModelValidator schemaAPersonModelValidator,
			IBOLSchemaAPersonMapper bolSchemaAPersonMapper,
			IDALSchemaAPersonMapper dalSchemaAPersonMapper)
			: base(logger,
			       mediator,
			       schemaAPersonRepository,
			       schemaAPersonModelValidator,
			       bolSchemaAPersonMapper,
			       dalSchemaAPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1567971d9561dc67d24fdcdfff51c17f</Hash>
</Codenesium>*/