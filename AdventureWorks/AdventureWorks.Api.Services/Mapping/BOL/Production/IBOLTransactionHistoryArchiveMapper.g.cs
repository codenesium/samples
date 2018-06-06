using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLTransactionHistoryArchiveMapper
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
    <Hash>0ad8d5bd9db72c6ae787ccdb980e0164</Hash>
</Codenesium>*/