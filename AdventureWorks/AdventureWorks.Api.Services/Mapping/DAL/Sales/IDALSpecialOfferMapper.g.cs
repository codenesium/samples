using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSpecialOfferMapper
	{
		SpecialOffer MapBOToEF(
			BOSpecialOffer bo);

		BOSpecialOffer MapEFToBO(
			SpecialOffer efSpecialOffer);

		List<BOSpecialOffer> MapEFToBO(
			List<SpecialOffer> records);
	}
}

/*<Codenesium>
    <Hash>96d60ae32d978c106bc0a24d5ca99747</Hash>
</Codenesium>*/