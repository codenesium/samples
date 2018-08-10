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
    <Hash>9821f9e6d9f147fa59cb762b1cc6b99f</Hash>
</Codenesium>*/