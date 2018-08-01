using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>ee7641bc88df6afb0904e664718a3551</Hash>
</Codenesium>*/