using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLEventMapper
	{
		BOEvent MapModelToBO(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventServerResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>a5f8b9543120a67c286f740ff07acaa8</Hash>
</Codenesium>*/