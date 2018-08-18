using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALContactTypeMapper
	{
		ContactType MapBOToEF(
			BOContactType bo);

		BOContactType MapEFToBO(
			ContactType efContactType);

		List<BOContactType> MapEFToBO(
			List<ContactType> records);
	}
}

/*<Codenesium>
    <Hash>f87a9615c9605c42db630b2987fa3d46</Hash>
</Codenesium>*/