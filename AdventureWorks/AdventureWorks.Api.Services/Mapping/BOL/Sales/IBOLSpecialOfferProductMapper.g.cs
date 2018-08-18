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
    <Hash>cebc7fc94d3566faedf7af848e60ea8d</Hash>
</Codenesium>*/