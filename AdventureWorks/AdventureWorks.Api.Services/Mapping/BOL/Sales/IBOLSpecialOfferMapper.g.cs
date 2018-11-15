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
			ApiSpecialOfferServerRequestModel model);

		ApiSpecialOfferServerResponseModel MapBOToModel(
			BOSpecialOffer boSpecialOffer);

		List<ApiSpecialOfferServerResponseModel> MapBOToModel(
			List<BOSpecialOffer> items);
	}
}

/*<Codenesium>
    <Hash>e49b60c34f7ec701a85c888e6073a16e</Hash>
</Codenesium>*/