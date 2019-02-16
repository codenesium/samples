using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base(logger,
			       mediator,
			       personRepository,
			       personModelValidator,
			       dalPersonMapper,
			       dalColumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7b170684e581ba58324895cf136a906f</Hash>
</Codenesium>*/