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
			List<BOProductListPriceHistory> bos);
	}
}

/*<Codenesium>
    <Hash>6c0600bb351eefe26d1482b5f1e266a2</Hash>
</Codenesium>*/