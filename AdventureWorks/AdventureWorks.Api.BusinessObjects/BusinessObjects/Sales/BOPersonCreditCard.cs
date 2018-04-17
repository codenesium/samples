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
	public class BOPersonCreditCard: AbstractBOPersonCreditCard, IBOPersonCreditCard
	{
		public BOPersonCreditCard(
			ILogger<PersonCreditCardRepository> logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator)
			: base(logger, personCreditCardRepository, personCreditCardModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>894879d5d5cd0c8a91091eb0c954d28f</Hash>
</Codenesium>*/