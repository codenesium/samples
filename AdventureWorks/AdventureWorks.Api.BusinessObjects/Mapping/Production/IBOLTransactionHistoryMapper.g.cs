using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLTransactionHistoryMapper
	{
		DTOTransactionHistory MapModelToDTO(
			int transactionID,
			ApiTransactionHistoryRequestModel model);

		ApiTransactionHistoryResponseModel MapDTOToModel(
			DTOTransactionHistory dtoTransactionHistory);

		List<ApiTransactionHistoryResponseModel> MapDTOToModel(
			List<DTOTransactionHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>ad9fa14af54dd8718ddb2102d87844d0</Hash>
</Codenesium>*/