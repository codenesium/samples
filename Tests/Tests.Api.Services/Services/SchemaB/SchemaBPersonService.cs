using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaBPersonService : AbstractSchemaBPersonService, ISchemaBPersonService
	{
		public SchemaBPersonService(
			ILogger<ISchemaBPersonRepository> logger,
			IMediator mediator,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonServerRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolSchemaBPersonMapper,
			IDALSchemaBPersonMapper dalSchemaBPersonMapper)
			: base(logger,
			       mediator,
			       schemaBPersonRepository,
			       schemaBPersonModelValidator,
			       bolSchemaBPersonMapper,
			       dalSchemaBPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>53b1c0fa4ec2dc4402edd50956d2c8a5</Hash>
</Codenesium>*/