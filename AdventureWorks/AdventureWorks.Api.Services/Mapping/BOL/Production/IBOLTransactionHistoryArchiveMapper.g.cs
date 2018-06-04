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
			List<BOTransactionHistoryArchive> bos);
	}
}

/*<Codenesium>
    <Hash>04b8bc7085d5305727cb950b5600718b</Hash>
</Codenesium>*/