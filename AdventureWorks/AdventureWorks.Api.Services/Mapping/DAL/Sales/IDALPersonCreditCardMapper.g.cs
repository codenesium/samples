using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>c8b9ffdbdeb98c0420666de3106a4b2c</Hash>
</Codenesium>*/