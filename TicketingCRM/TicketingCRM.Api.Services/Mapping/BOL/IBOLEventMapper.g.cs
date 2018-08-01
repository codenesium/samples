using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLEventMapper
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
    <Hash>2833e2f27df350cf9e7ce20b181975a2</Hash>
</Codenesium>*/