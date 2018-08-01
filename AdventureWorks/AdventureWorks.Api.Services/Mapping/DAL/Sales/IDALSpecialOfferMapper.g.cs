using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALSpecialOfferMapper
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
    <Hash>a6e2b84cc223a625c4e12f60372097c5</Hash>
</Codenesium>*/