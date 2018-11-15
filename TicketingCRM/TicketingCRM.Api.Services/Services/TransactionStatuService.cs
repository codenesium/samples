using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionStatuService : AbstractTransactionStatuService, ITransactionStatuService
	{
		public TransactionStatuService(
			ILogger<ITransactionStatuRepository> logger,
			ITransactionStatuRepository transactionStatuRepository,
			IApiTransactionStatuServerRequestModelValidator transactionStatuModelValidator,
			IBOLTransactionStatuMapper bolTransactionStatuMapper,
			IDALTransactionStatuMapper dalTransactionStatuMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base(logger,
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
    <Hash>80e08b231aadeb8e12baea21f5afb64c</Hash>
</Codenesium>*/