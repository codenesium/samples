using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTicketStatusMapper
	{
		BOTicketStatus MapModelToBO(
			int id,
			ApiTicketStatusRequestModel model);

		ApiTicketStatusResponseModel MapBOToModel(
			BOTicketStatus boTicketStatus);

		List<ApiTicketStatusResponseModel> MapBOToModel(
			List<BOTicketStatus> items);
	}
}

/*<Codenesium>
    <Hash>2b484f022930ca547b1bc225a392e4a9</Hash>
</Codenesium>*/