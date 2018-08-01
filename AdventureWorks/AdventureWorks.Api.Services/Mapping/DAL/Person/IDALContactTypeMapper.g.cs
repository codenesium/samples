using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALContactTypeMapper
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
    <Hash>90c7ab3069c22e8f728fc0dbccdbce5e</Hash>
</Codenesium>*/