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
			IDALTransactionHistoryMapper dalTransactionHistoryMapper)
			: base(logger,
			       mediator,
			       transactionHistoryRepository,
			       transactionHistoryModelValidator,
			       dalTransactionHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>19f90f04fce66a0015623c52d5f1596f</Hash>
</Codenesium>*/