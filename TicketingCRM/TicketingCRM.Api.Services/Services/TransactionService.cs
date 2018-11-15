using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionService : AbstractTransactionService, ITransactionService
	{
		public TransactionService(
			ILogger<ITransactionRepository> logger,
			ITransactionRepository transactionRepository,
			IApiTransactionServerRequestModelValidator transactionModelValidator,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       transactionRepository,
			       transactionModelValidator,
			       bolTransactionMapper,
			       dalTransactionMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>44e87f6fca3850209eb56c068259a02d</Hash>
</Codenesium>*/