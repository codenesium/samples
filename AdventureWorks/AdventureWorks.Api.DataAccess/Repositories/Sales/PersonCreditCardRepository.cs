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
	public partial class PersonCreditCardRepository : AbstractPersonCreditCardRepository, IPersonCreditCardRepository
	{
		public PersonCreditCardRepository(
			ILogger<PersonCreditCardRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>df1854159e09c56b5131a2adaa385fc7</Hash>
</Codenesium>*/