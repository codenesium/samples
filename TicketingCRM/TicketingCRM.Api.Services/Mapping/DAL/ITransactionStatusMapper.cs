using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionStatusMapper
	{
		TransactionStatus MapModelToEntity(
			int id,
			ApiTransactionStatusServerRequestModel model);

		ApiTransactionStatusServerResponseModel MapEntityToModel(
			TransactionStatus item);

		List<ApiTransactionStatusServerResponseModel> MapEntityToModel(
			List<TransactionStatus> items);
	}
}

/*<Codenesium>
    <Hash>cafc7875dd3b10492cc15797ba0182c2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/