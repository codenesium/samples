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
    <Hash>ade705cbfcd589de7f39b5531a86a3b1</Hash>
</Codenesium>*/