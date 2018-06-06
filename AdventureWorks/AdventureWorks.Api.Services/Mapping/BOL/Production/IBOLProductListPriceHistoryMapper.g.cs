using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductListPriceHistoryMapper
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
    <Hash>b4c092ff6b99780ee878274368d72bb6</Hash>
</Codenesium>*/