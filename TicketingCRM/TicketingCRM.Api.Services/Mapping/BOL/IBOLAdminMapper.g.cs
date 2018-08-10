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
			ApiAdminRequestModel model);

		ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>75c184bec9ccaf088194bc385b7b6bda</Hash>
</Codenesium>*/