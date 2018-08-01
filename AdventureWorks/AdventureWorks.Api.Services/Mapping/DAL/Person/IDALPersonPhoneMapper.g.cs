using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALPersonPhoneMapper
	{
		PersonPhone MapBOToEF(
			BOPersonPhone bo);

		BOPersonPhone MapEFToBO(
			PersonPhone efPersonPhone);

		List<BOPersonPhone> MapEFToBO(
			List<PersonPhone> records);
	}
}

/*<Codenesium>
    <Hash>08bd1479e373df0977c1e3c1e17fbd77</Hash>
</Codenesium>*/