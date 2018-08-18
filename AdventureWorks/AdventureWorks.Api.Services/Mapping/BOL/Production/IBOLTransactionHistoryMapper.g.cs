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
    <Hash>3e107ddc8e803e5d2be1954a57107a83</Hash>
</Codenesium>*/