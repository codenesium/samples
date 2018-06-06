using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLTransactionHistoryMapper
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
    <Hash>cc98f252065322e410411ea6a2e57bba</Hash>
</Codenesium>*/