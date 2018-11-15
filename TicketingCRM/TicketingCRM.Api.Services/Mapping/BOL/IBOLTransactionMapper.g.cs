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
			ApiTransactionServerRequestModel model);

		ApiTransactionServerResponseModel MapBOToModel(
			BOTransaction boTransaction);

		List<ApiTransactionServerResponseModel> MapBOToModel(
			List<BOTransaction> items);
	}
}

/*<Codenesium>
    <Hash>d5ca6d08e4965a3e859fafb0675a709d</Hash>
</Codenesium>*/