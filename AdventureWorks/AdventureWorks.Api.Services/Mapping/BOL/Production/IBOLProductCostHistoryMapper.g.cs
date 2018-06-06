using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductCostHistoryMapper
	{
		BOProductCostHistory MapModelToBO(
			int productID,
			ApiProductCostHistoryRequestModel model);

		ApiProductCostHistoryResponseModel MapBOToModel(
			BOProductCostHistory boProductCostHistory);

		List<ApiProductCostHistoryResponseModel> MapBOToModel(
			List<BOProductCostHistory> items);
	}
}

/*<Codenesium>
    <Hash>7d28f8d54cb09fc004ad9574d9e1e666</Hash>
</Codenesium>*/