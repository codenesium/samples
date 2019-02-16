using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionService : AbstractTransactionService, ITransactionService
	{
		public TransactionService(
			ILogger<ITransactionRepository> logger,
			IMediator mediator,
			ITransactionRepository transactionRepository,
			IApiTransactionServerRequestModelValidator transactionModelValidator,
			IDALTransactionMapper dalTransactionMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       mediator,
			       transactionRepository,
			       transactionModelValidator,
			       dalTransactionMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f298c128d10ad93b8dd746efc83ac4e5</Hash>
</Codenesium>*/