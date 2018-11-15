using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class TransactionHistoryArchiveService : AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
	{
		public TransactionHistoryArchiveService(
			ILogger<ITransactionHistoryArchiveRepository> logger,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveServerRequestModelValidator transactionHistoryArchiveModelValidator,
			IBOLTransactionHistoryArchiveMapper bolTransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper)
			: base(logger,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       bolTransactionHistoryArchiveMapper,
			       dalTransactionHistoryArchiveMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d3625eca5aab05894e9301037e8c56a2</Hash>
</Codenesium>*/