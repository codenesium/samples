using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>f21b16c6d396770434299fb9956c14c9</Hash>
</Codenesium>*/