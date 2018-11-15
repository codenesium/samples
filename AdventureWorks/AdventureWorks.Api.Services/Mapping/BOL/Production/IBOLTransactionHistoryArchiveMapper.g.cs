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
			ApiTransactionHistoryArchiveServerRequestModel model);

		ApiTransactionHistoryArchiveServerResponseModel MapBOToModel(
			BOTransactionHistoryArchive boTransactionHistoryArchive);

		List<ApiTransactionHistoryArchiveServerResponseModel> MapBOToModel(
			List<BOTransactionHistoryArchive> items);
	}
}

/*<Codenesium>
    <Hash>3e5c08dbb980e03fed0b0eb72ec8789d</Hash>
</Codenesium>*/