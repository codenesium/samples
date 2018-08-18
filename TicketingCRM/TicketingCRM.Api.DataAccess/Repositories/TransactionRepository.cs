using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TransactionRepository : AbstractTransactionRepository, ITransactionRepository
	{
		public TransactionRepository(
			ILogger<TransactionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9f6432020a7ab378c86d4ada14973fab</Hash>
</Codenesium>*/