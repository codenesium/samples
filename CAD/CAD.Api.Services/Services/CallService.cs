using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallService : AbstractCallService, ICallService
	{
		public CallService(
			ILogger<ICallRepository> logger,
			IMediator mediator,
			ICallRepository callRepository,
			IApiCallServerRequestModelValidator callModelValidator,
			IDALCallMapper dalCallMapper,
			IDALNoteMapper dalNoteMapper)
			: base(logger,
			       mediator,
			       callRepository,
			       callModelValidator,
			       dalCallMapper,
			       dalNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ff104cbb34988730cdeb872a96efaf82</Hash>
</Codenesium>*/