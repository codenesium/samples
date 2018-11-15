using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLAdminMapper
	{
		BOAdmin MapModelToBO(
			int id,
			ApiAdminServerRequestModel model);

		ApiAdminServerResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminServerResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>e5471efef6396ec0979b8d892aa8efd1</Hash>
</Codenesium>*/