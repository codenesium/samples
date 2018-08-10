using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesPersonQuotaHistoryMapper
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
    <Hash>484e1e083788383a8a5635efa071b8af</Hash>
</Codenesium>*/