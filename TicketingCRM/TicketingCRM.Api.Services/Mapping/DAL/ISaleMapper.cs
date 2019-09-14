using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALSaleMapper
	{
		Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model);

		ApiSaleServerResponseModel MapEntityToModel(
			Sale item);

		List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items);
	}
}

/*<Codenesium>
    <Hash>5effd1491f52a7ff641912db80809659</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/