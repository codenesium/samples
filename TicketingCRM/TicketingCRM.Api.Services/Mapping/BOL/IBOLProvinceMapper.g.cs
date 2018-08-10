using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLProvinceMapper
	{
		BOProvince MapModelToBO(
			int id,
			ApiProvinceRequestModel model);

		ApiProvinceResponseModel MapBOToModel(
			BOProvince boProvince);

		List<ApiProvinceResponseModel> MapBOToModel(
			List<BOProvince> items);
	}
}

/*<Codenesium>
    <Hash>b31fd7d15da34496ca7a0173ef81e516</Hash>
</Codenesium>*/