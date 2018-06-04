using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALPersonCreditCardMapper
	{
		PersonCreditCard MapBOToEF(
			BOPersonCreditCard bo);

		BOPersonCreditCard MapEFToBO(
			PersonCreditCard efPersonCreditCard);

		List<BOPersonCreditCard> MapEFToBO(
			List<PersonCreditCard> records);
	}
}

/*<Codenesium>
    <Hash>9046665f38bc63a47185e75f7620f9e0</Hash>
</Codenesium>*/