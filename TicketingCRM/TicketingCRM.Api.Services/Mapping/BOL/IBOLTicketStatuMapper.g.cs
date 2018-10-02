using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTicketStatuMapper
	{
		BOTicketStatu MapModelToBO(
			int id,
			ApiTicketStatuRequestModel model);

		ApiTicketStatuResponseModel MapBOToModel(
			BOTicketStatu boTicketStatu);

		List<ApiTicketStatuResponseModel> MapBOToModel(
			List<BOTicketStatu> items);
	}
}

/*<Codenesium>
    <Hash>e09298035ae931bcd2d821a9c361f19f</Hash>
</Codenesium>*/