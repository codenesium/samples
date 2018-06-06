using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSpecialOfferProductMapper
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
    <Hash>7e4cb2457bf3b5689f74ef6daa887d98</Hash>
</Codenesium>*/