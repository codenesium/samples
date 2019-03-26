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
    <Hash>55aaf578ccf908ed65526d733db4beaa</Hash>
</Codenesium>*/