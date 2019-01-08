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
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base(logger,
			       mediator,
			       personRepository,
			       personModelValidator,
			       bolPersonMapper,
			       dalPersonMapper,
			       bolColumnSameAsFKTableMapper,
			       dalColumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e3b48e5d405c85fbe93c9cb59461c1ea</Hash>
</Codenesium>*/