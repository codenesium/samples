using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTransactionMapper
	{
		Transaction MapModelToEntity(
			int id,
			ApiTransactionServerRequestModel model);

		ApiTransactionServerResponseModel MapEntityToModel(
			Transaction item);

		List<ApiTransactionServerResponseModel> MapEntityToModel(
			List<Transaction> items);
	}
}

/*<Codenesium>
    <Hash>2a94c264d4873f1711790a4663e4c1a0</Hash>
</Codenesium>*/