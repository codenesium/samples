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
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base(logger,
			       mediator,
			       personRepository,
			       personModelValidator,
			       bolPersonMapper,
			       dalPersonMapper,
			       bolPasswordMapper,
			       dalPasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fbd180b0904f5dcc0f3dea11ffafd86f</Hash>
</Codenesium>*/