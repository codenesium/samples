using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionStatuService : AbstractTransactionStatuService, ITransactionStatuService
	{
		public TransactionStatuService(
			ILogger<ITransactionStatuRepository> logger,
			IMediator mediator,
			ITransactionStatuRepository transactionStatuRepository,
			IApiTransactionStatuServerRequestModelValidator transactionStatuModelValidator,
			IBOLTransactionStatuMapper bolTransactionStatuMapper,
			IDALTransactionStatuMapper dalTransactionStatuMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base(logger,
			       mediator,
			       transactionStatuRepository,
			       transactionStatuModelValidator,
			       bolTransactionStatuMapper,
			       dalTransactionStatuMapper,
			       bolTransactionMapper,
			       dalTransactionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>627200721e14dfcf0bc4b6a4582d9367</Hash>
</Codenesium>*/