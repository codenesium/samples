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
			List<BOSpecialOffer> bos);
	}
}

/*<Codenesium>
    <Hash>d0d65350b6f02adbbf647c03dca4b161</Hash>
</Codenesium>*/