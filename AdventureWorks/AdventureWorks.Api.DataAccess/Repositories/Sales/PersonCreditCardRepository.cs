using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PersonCreditCardRepository: AbstractPersonCreditCardRepository, IPersonCreditCardRepository
	{
		public PersonCreditCardRepository(
			ILogger<PersonCreditCardRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8b34f4a1103cb0a07c2a05203bd237cd</Hash>
</Codenesium>*/