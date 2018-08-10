using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTransactionMapper
	{
		BOTransaction MapModelToBO(
			int id,
			ApiTransactionRequestModel model);

		ApiTransactionResponseModel MapBOToModel(
			BOTransaction boTransaction);

		List<ApiTransactionResponseModel> MapBOToModel(
			List<BOTransaction> items);
	}
}

/*<Codenesium>
    <Hash>d2bc585fb2f20baddea719a3574fa7c2</Hash>
</Codenesium>*/