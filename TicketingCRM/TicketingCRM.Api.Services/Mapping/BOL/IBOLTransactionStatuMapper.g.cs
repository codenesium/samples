using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTransactionStatuMapper
	{
		BOTransactionStatu MapModelToBO(
			int id,
			ApiTransactionStatuRequestModel model);

		ApiTransactionStatuResponseModel MapBOToModel(
			BOTransactionStatu boTransactionStatu);

		List<ApiTransactionStatuResponseModel> MapBOToModel(
			List<BOTransactionStatu> items);
	}
}

/*<Codenesium>
    <Hash>a1517595e8823bc017b6c41504a036cf</Hash>
</Codenesium>*/