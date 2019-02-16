using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALAdminMapper
	{
		Admin MapModelToEntity(
			int id,
			ApiAdminServerRequestModel model);

		ApiAdminServerResponseModel MapEntityToModel(
			Admin item);

		List<ApiAdminServerResponseModel> MapEntityToModel(
			List<Admin> items);
	}
}

/*<Codenesium>
    <Hash>a86d5b51b653f8628fadba54de04f85e</Hash>
</Codenesium>*/