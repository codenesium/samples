using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCreditCard: AbstractBOCreditCard, IBOCreditCard
	{
		public BOCreditCard(
			ILogger<CreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator)
			: base(logger, creditCardRepository, creditCardModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>10261f8de7773e56cf25af98818c2575</Hash>
</Codenesium>*/