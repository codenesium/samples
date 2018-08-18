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
			ApiEventRequestModel model);

		ApiEventResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>5810d7099e904febb071ce74c1b0cd57</Hash>
</Codenesium>*/