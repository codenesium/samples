using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSpecialOfferMapper
	{
		SpecialOffer MapModelToEntity(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel model);

		ApiSpecialOfferServerResponseModel MapEntityToModel(
			SpecialOffer item);

		List<ApiSpecialOfferServerResponseModel> MapEntityToModel(
			List<SpecialOffer> items);
	}
}

/*<Codenesium>
    <Hash>18bc84f24aee84792c7c28a3439ba474</Hash>
</Codenesium>*/