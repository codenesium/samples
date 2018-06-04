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
			List<BOSpecialOfferProduct> bos);
	}
}

/*<Codenesium>
    <Hash>7eeebb7968ba9a0789d0f69ebee3a7e0</Hash>
</Codenesium>*/