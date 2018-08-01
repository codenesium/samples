using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLTransactionStatusMapper
	{
		BOTransactionStatus MapModelToBO(
			int id,
			ApiTransactionStatusRequestModel model);

		ApiTransactionStatusResponseModel MapBOToModel(
			BOTransactionStatus boTransactionStatus);

		List<ApiTransactionStatusResponseModel> MapBOToModel(
			List<BOTransactionStatus> items);
	}
}

/*<Codenesium>
    <Hash>2e7b85269f548adcd2653ac7ad3cf6a1</Hash>
</Codenesium>*/