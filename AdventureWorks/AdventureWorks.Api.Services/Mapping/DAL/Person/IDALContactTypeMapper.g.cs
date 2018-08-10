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
    <Hash>19f7084cc100b10b3fd5b1c680b2da81</Hash>
</Codenesium>*/