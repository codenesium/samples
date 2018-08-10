using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSpecialOfferMapper
	{
		BOSpecialOffer MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferRequestModel model);

		ApiSpecialOfferResponseModel MapBOToModel(
			BOSpecialOffer boSpecialOffer);

		List<ApiSpecialOfferResponseModel> MapBOToModel(
			List<BOSpecialOffer> items);
	}
}

/*<Codenesium>
    <Hash>9a261619aee0bf0e14958580df052ecb</Hash>
</Codenesium>*/