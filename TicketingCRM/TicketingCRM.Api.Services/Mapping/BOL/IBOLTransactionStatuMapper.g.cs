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
			ApiTransactionStatuServerRequestModel model);

		ApiTransactionStatuServerResponseModel MapBOToModel(
			BOTransactionStatu boTransactionStatu);

		List<ApiTransactionStatuServerResponseModel> MapBOToModel(
			List<BOTransactionStatu> items);
	}
}

/*<Codenesium>
    <Hash>d6cd230a7a155a9e20a78cf376670c7d</Hash>
</Codenesium>*/