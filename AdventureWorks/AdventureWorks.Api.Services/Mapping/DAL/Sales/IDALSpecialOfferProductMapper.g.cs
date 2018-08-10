using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSpecialOfferProductMapper
	{
		SpecialOfferProduct MapBOToEF(
			BOSpecialOfferProduct bo);

		BOSpecialOfferProduct MapEFToBO(
			SpecialOfferProduct efSpecialOfferProduct);

		List<BOSpecialOfferProduct> MapEFToBO(
			List<SpecialOfferProduct> records);
	}
}

/*<Codenesium>
    <Hash>e4f80fb2b1d9d72eab44c735f81bfdf0</Hash>
</Codenesium>*/