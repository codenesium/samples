using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TransactionStatuService : AbstractTransactionStatuService, ITransactionStatuService
	{
		public TransactionStatuService(
			ILogger<ITransactionStatuRepository> logger,
			ITransactionStatuRepository transactionStatuRepository,
			IApiTransactionStatuRequestModelValidator transactionStatuModelValidator,
			IBOLTransactionStatuMapper boltransactionStatuMapper,
			IDALTransactionStatuMapper daltransactionStatuMapper,
			IBOLTransactionMapper bolTransactionMapper,
			IDALTransactionMapper dalTransactionMapper)
			: base(logger,
			       transactionStatuRepository,
			       transactionStatuModelValidator,
			       boltransactionStatuMapper,
			       daltransactionStatuMapper,
			       bolTransactionMapper,
			       dalTransactionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d9754450764ff612a2a7beb6250639de</Hash>
</Codenesium>*/