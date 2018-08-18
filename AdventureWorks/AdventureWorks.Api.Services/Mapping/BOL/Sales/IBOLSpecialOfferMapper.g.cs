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
    <Hash>c371eb8ddc03875cf05994b224ed8391</Hash>
</Codenesium>*/