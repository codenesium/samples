using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class TransactionHistoryArchiveRepository: AbstractTransactionHistoryArchiveRepository, ITransactionHistoryArchiveRepository
	{
		public TransactionHistoryArchiveRepository(
			ILogger<TransactionHistoryArchiveRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b9b9d7d17f45e6ae2dd55673713a0c65</Hash>
</Codenesium>*/