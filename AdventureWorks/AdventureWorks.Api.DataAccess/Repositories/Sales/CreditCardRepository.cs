using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class CreditCardRepository : AbstractCreditCardRepository, ICreditCardRepository
	{
		public CreditCardRepository(
			ILogger<CreditCardRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>94b39d071b82ffcb58ff2ba0552a8ebd</Hash>
</Codenesium>*/