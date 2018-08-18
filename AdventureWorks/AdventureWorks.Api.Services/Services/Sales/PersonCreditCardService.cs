using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class PersonCreditCardService : AbstractPersonCreditCardService, IPersonCreditCardService
	{
		public PersonCreditCardService(
			ILogger<IPersonCreditCardRepository> logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper bolpersonCreditCardMapper,
			IDALPersonCreditCardMapper dalpersonCreditCardMapper
			)
			: base(logger,
			       personCreditCardRepository,
			       personCreditCardModelValidator,
			       bolpersonCreditCardMapper,
			       dalpersonCreditCardMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fb4f68b6e706f2c17a8b8c5c2512bcb7</Hash>
</Codenesium>*/