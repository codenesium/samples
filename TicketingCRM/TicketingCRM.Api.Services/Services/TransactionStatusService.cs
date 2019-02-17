using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionStatusService : AbstractTransactionStatusService, ITransactionStatusService
	{
		public TransactionStatusService(
			ILogger<ITransactionStatusRepository> logger,
			IMediator mediator,
			ITransactionStatusRepository transactionStatusRepository,
			IApiTransactionStatusServerRequestModelValidator transactionStatusModelValidator,
			IDALTransactionStatusMapper dalTransactionStatusMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base(logger,
			       mediator,
			       transactionStatusRepository,
			       transactionStatusModelValidator,
			       dalTransactionStatusMapper,
			       dalTransactionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c8200d3ac54b5f597981f9e7abf1b15f</Hash>
</Codenesium>*/