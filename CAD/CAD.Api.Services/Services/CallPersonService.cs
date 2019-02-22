using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallPersonService : AbstractCallPersonService, ICallPersonService
	{
		public CallPersonService(
			ILogger<ICallPersonRepository> logger,
			IMediator mediator,
			ICallPersonRepository callPersonRepository,
			IApiCallPersonServerRequestModelValidator callPersonModelValidator,
			IDALCallPersonMapper dalCallPersonMapper)
			: base(logger,
			       mediator,
			       callPersonRepository,
			       callPersonModelValidator,
			       dalCallPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b36cceb7460bf3fa07403dcf07f61bb9</Hash>
</Codenesium>*/