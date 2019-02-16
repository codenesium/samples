using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionStatuMapper
	{
		TransactionStatu MapModelToEntity(
			int id,
			ApiTransactionStatuServerRequestModel model);

		ApiTransactionStatuServerResponseModel MapEntityToModel(
			TransactionStatu item);

		List<ApiTransactionStatuServerResponseModel> MapEntityToModel(
			List<TransactionStatu> items);
	}
}

/*<Codenesium>
    <Hash>cb16a23e86ea459e59fe1a2929d066ea</Hash>
</Codenesium>*/