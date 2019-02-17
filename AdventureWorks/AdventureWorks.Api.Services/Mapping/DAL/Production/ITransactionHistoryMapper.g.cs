using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryMapper
	{
		TransactionHistory MapModelToEntity(
			int transactionID,
			ApiTransactionHistoryServerRequestModel model);

		ApiTransactionHistoryServerResponseModel MapEntityToModel(
			TransactionHistory item);

		List<ApiTransactionHistoryServerResponseModel> MapEntityToModel(
			List<TransactionHistory> items);
	}
}

/*<Codenesium>
    <Hash>48cda767068ce709525531c28e6bd18c</Hash>
</Codenesium>*/