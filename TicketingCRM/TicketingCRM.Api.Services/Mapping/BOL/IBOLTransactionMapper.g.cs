using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLTransactionMapper
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
    <Hash>5affbdf7613477c9b6ad338a0bba87ab</Hash>
</Codenesium>*/