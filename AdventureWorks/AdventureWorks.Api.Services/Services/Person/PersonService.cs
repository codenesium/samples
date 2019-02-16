using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       mediator,
			       personRepository,
			       personModelValidator,
			       dalPersonMapper,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>27276b543c5b70076e5304f7e00671c7</Hash>
</Codenesium>*/