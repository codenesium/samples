using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryMapper
	{
		TransactionHistory MapModelToBO(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model);

		ApiTransactionHistoryServerResponseModel MapBOToModel(
			TransactionHistory item);

		List<ApiTransactionHistoryServerResponseModel> MapBOToModel(
			List<TransactionHistory> items);
	}
}

/*<Codenesium>
    <Hash>e3b24ff363e5334980dd1f30be475151</Hash>
</Codenesium>*/