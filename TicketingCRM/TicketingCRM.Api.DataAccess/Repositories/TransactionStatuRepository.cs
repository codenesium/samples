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
	public partial class TransactionStatuRepository : AbstractTransactionStatuRepository, ITransactionStatuRepository
	{
		public TransactionStatuRepository(
			ILogger<TransactionStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4f0b9e48c512831e7ca3575282ffaa3b</Hash>
</Codenesium>*/