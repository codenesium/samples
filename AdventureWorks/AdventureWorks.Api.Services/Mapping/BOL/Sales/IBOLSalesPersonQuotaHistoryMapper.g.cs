using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesPersonQuotaHistoryMapper
	{
		BOSalesPersonQuotaHistory MapModelToBO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model);

		ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
			BOSalesPersonQuotaHistory boSalesPersonQuotaHistory);

		List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
			List<BOSalesPersonQuotaHistory> items);
	}
}

/*<Codenesium>
    <Hash>2f4cd40d31c8b2bdc5214bec26003db9</Hash>
</Codenesium>*/