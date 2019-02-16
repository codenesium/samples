using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class TransactionHistoryArchiveService : AbstractTransactionHistoryArchiveService, ITransactionHistoryArchiveService
	{
		public TransactionHistoryArchiveService(
			ILogger<ITransactionHistoryArchiveRepository> logger,
			IMediator mediator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			IApiTransactionHistoryArchiveServerRequestModelValidator transactionHistoryArchiveModelValidator,
			IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper)
			: base(logger,
			       mediator,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       dalTransactionHistoryArchiveMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6b4ee06e1336771920ba19bacf20a8f</Hash>
</Codenesium>*/