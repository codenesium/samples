using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>850efa4172de0325668712a77505e04b</Hash>
</Codenesium>*/