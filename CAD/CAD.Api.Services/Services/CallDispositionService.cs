using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallDispositionService : AbstractCallDispositionService, ICallDispositionService
	{
		public CallDispositionService(
			ILogger<ICallDispositionRepository> logger,
			IMediator mediator,
			ICallDispositionRepository callDispositionRepository,
			IApiCallDispositionServerRequestModelValidator callDispositionModelValidator,
			IDALCallDispositionMapper dalCallDispositionMapper,
			IDALCallMapper dalCallMapper)
			: base(logger,
			       mediator,
			       callDispositionRepository,
			       callDispositionModelValidator,
			       dalCallDispositionMapper,
			       dalCallMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b34596037e2051a22ede3aea6b433241</Hash>
</Codenesium>*/