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
			List<BOProductCostHistory> bos);
	}
}

/*<Codenesium>
    <Hash>c7e9cab01712e7d74f7d3902fb4bd0a3</Hash>
</Codenesium>*/