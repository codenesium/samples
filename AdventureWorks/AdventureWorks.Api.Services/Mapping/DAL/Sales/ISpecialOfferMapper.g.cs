using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSpecialOfferMapper
	{
		SpecialOffer MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel model);

		ApiSpecialOfferServerResponseModel MapBOToModel(
			SpecialOffer item);

		List<ApiSpecialOfferServerResponseModel> MapBOToModel(
			List<SpecialOffer> items);
	}
}

/*<Codenesium>
    <Hash>00a993c59e77aa86d44163a5310c8688</Hash>
</Codenesium>*/