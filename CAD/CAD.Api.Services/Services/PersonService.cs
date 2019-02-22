using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class PersonService : AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<IPersonRepository> logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALCallPersonMapper dalCallPersonMapper)
			: base(logger,
			       mediator,
			       personRepository,
			       personModelValidator,
			       dalPersonMapper,
			       dalCallPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c4978c3b649948b5c6b78cfa1adc84b2</Hash>
</Codenesium>*/