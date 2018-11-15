using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class TransactionHistoryService : AbstractTransactionHistoryService, ITransactionHistoryService
	{
		public TransactionHistoryService(
			ILogger<ITransactionHistoryRepository> logger,
			ITransactionHistoryRepository transactionHistoryRepository,
			IApiTransactionHistoryServerRequestModelValidator transactionHistoryModelValidator,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper)
			: base(logger,
			       transactionHistoryRepository,
			       transactionHistoryModelValidator,
			       bolTransactionHistoryMapper,
			       dalTransactionHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8aa82bd7c48e2f2f2be21b6835fa7510</Hash>
</Codenesium>*/