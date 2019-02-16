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
			IDALTransactionStatuMapper dalTransactionStatuMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base(logger,
			       mediator,
			       transactionStatuRepository,
			       transactionStatuModelValidator,
			       dalTransactionStatuMapper,
			       dalTransactionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>472617eee26d3aff2b140b7727c588af</Hash>
</Codenesium>*/