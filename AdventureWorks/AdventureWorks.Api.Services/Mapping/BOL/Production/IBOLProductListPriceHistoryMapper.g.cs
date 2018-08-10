using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductListPriceHistoryMapper
	{
		BOProductListPriceHistory MapModelToBO(
			int productID,
			ApiProductListPriceHistoryRequestModel model);

		ApiProductListPriceHistoryResponseModel MapBOToModel(
			BOProductListPriceHistory boProductListPriceHistory);

		List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
			List<BOProductListPriceHistory> items);
	}
}

/*<Codenesium>
    <Hash>79f38784ebc08815fc90418375f9ef82</Hash>
</Codenesium>*/