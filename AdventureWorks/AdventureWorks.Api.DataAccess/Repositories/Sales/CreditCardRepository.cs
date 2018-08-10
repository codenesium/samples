using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>46ce2955beda5af161b154e187f7fad6</Hash>
</Codenesium>*/