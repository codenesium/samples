using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLTransactionHistoryMapper
	{
		BOTransactionHistory MapModelToBO(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model);

		ApiTransactionHistoryServerResponseModel MapBOToModel(
			BOTransactionHistory boTransactionHistory);

		List<ApiTransactionHistoryServerResponseModel> MapBOToModel(
			List<BOTransactionHistory> items);
	}
}

/*<Codenesium>
    <Hash>d7d6046e4370d34510c4a16f858d1862</Hash>
</Codenesium>*/