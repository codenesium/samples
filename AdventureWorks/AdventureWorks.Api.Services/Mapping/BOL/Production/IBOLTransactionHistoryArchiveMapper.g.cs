using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLTransactionHistoryArchiveMapper
	{
		BOTransactionHistoryArchive MapModelToBO(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model);

		ApiTransactionHistoryArchiveResponseModel MapBOToModel(
			BOTransactionHistoryArchive boTransactionHistoryArchive);

		List<ApiTransactionHistoryArchiveResponseModel> MapBOToModel(
			List<BOTransactionHistoryArchive> items);
	}
}

/*<Codenesium>
    <Hash>cf2101f5db38533e7adad95b1aed924f</Hash>
</Codenesium>*/