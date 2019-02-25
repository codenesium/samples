using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryArchiveMapper
	{
		TransactionHistoryArchive MapModelToEntity(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel model);

		ApiTransactionHistoryArchiveServerResponseModel MapEntityToModel(
			TransactionHistoryArchive item);

		List<ApiTransactionHistoryArchiveServerResponseModel> MapEntityToModel(
			List<TransactionHistoryArchive> items);
	}
}

/*<Codenesium>
    <Hash>976792f5aa7f5b3b92ed11ac12d38afe</Hash>
</Codenesium>*/