using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALTransactionHistoryArchiveMapper
	{
		TransactionHistoryArchive MapModelToBO(
			int transactionID,
			ApiTransactionHistoryArchiveServerRequestModel model);

		ApiTransactionHistoryArchiveServerResponseModel MapBOToModel(
			TransactionHistoryArchive item);

		List<ApiTransactionHistoryArchiveServerResponseModel> MapBOToModel(
			List<TransactionHistoryArchive> items);
	}
}

/*<Codenesium>
    <Hash>87775f40410f7ce047290353d7cdf4c4</Hash>
</Codenesium>*/