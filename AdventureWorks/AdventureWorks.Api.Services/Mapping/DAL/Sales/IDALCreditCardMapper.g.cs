using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>cf0d3f1af5be3a9fc9c96b0a6ba26c8d</Hash>
</Codenesium>*/