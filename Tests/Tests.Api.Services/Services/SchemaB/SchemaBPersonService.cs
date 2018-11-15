using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaBPersonService : AbstractSchemaBPersonService, ISchemaBPersonService
	{
		public SchemaBPersonService(
			ILogger<ISchemaBPersonRepository> logger,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonServerRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolSchemaBPersonMapper,
			IDALSchemaBPersonMapper dalSchemaBPersonMapper)
			: base(logger,
			       schemaBPersonRepository,
			       schemaBPersonModelValidator,
			       bolSchemaBPersonMapper,
			       dalSchemaBPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e7178ce578ad633321bd084b39c1e7d7</Hash>
</Codenesium>*/