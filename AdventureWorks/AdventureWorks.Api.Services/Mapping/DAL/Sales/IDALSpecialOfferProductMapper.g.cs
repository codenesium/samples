using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSpecialOfferProductMapper
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
    <Hash>980c5a12e606d5442066f59754410dbf</Hash>
</Codenesium>*/