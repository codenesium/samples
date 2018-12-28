using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class TransactionHistoryService : AbstractTransactionHistoryService, ITransactionHistoryService
	{
		public TransactionHistoryService(
			ILogger<ITransactionHistoryRepository> logger,
			IMediator mediator,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryServerRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper)
			: base(logger,
			       mediator,
			       transactionHistoryRepository,
			       transactionHistoryModelValidator,
			       bolTransactionHistoryMapper,
			       dalTransactionHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c4356d7f44d10b6a54d9b24cad825265</Hash>
</Codenesium>*/