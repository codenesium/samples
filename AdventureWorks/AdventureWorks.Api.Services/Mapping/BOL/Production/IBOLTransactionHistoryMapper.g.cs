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
			ApiTransactionHistoryRequestModel model);

		ApiTransactionHistoryResponseModel MapBOToModel(
			BOTransactionHistory boTransactionHistory);

		List<ApiTransactionHistoryResponseModel> MapBOToModel(
			List<BOTransactionHistory> items);
	}
}

/*<Codenesium>
    <Hash>77638b262ae47a324f132f8818ceb0ca</Hash>
</Codenesium>*/