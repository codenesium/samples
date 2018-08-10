using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLTransactionStatusMapper
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
    <Hash>3d74bc7f780c3dccc02c8b5390543308</Hash>
</Codenesium>*/