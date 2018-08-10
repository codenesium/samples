using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSpecialOfferProductMapper
	{
		BOSpecialOfferProduct MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model);

		ApiSpecialOfferProductResponseModel MapBOToModel(
			BOSpecialOfferProduct boSpecialOfferProduct);

		List<ApiSpecialOfferProductResponseModel> MapBOToModel(
			List<BOSpecialOfferProduct> items);
	}
}

/*<Codenesium>
    <Hash>b0ae6a707b3b702d7ef140d02bc9b38e</Hash>
</Codenesium>*/