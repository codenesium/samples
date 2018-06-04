using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>3e0f2364bdb6d00e0426c5e9ffe6d868</Hash>
</Codenesium>*/