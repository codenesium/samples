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
			IBOLTransactionHistoryArchiveMapper bolTransactionHistoryArchiveMapper,
			IDALTransactionHistoryArchiveMapper dalTransactionHistoryArchiveMapper)
			: base(logger,
			       mediator,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator,
			       bolTransactionHistoryArchiveMapper,
			       dalTransactionHistoryArchiveMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b641766a37704790f6197c8a87fbb9fa</Hash>
</Codenesium>*/