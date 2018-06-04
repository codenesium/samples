using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CreditCardRepository: AbstractCreditCardRepository, ICreditCardRepository
	{
		public CreditCardRepository(
			ILogger<CreditCardRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7fc11df9bdb89e31e0838f89244f2457</Hash>
</Codenesium>*/