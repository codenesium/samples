using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSpecialOfferMapper
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
    <Hash>7e79a1e854a75bfdb424c555e5c1be98</Hash>
</Codenesium>*/