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
    <Hash>457ac9e27cef3ba4434e5e6897073d62</Hash>
</Codenesium>*/