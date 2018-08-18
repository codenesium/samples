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
    <Hash>f712c3afa3fdda52e76f313b9bf68367</Hash>
</Codenesium>*/