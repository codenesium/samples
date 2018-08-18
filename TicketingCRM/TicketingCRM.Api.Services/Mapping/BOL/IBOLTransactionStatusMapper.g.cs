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
    <Hash>9979052c3f4a4a777e3d826b24a4e69a</Hash>
</Codenesium>*/