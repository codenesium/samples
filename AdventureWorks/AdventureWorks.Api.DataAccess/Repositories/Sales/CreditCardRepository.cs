using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CreditCardRepository: AbstractCreditCardRepository, ICreditCardRepository
	{
		public CreditCardRepository(
			IDALCreditCardMapper mapper,
			ILogger<CreditCardRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ca4df6fbf77d418a55f8e4488e5032f1</Hash>
</Codenesium>*/