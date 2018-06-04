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
			List<BOTransactionHistory> bos);
	}
}

/*<Codenesium>
    <Hash>5061b01639e768bc607c1d0d18ec0c12</Hash>
</Codenesium>*/