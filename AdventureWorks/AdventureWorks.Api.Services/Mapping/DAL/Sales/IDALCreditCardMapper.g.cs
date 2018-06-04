using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALCreditCardMapper
	{
		CreditCard MapBOToEF(
			BOCreditCard bo);

		BOCreditCard MapEFToBO(
			CreditCard efCreditCard);

		List<BOCreditCard> MapEFToBO(
			List<CreditCard> records);
	}
}

/*<Codenesium>
    <Hash>998e65e3fc877b29b520aa7d174f91e6</Hash>
</Codenesium>*/