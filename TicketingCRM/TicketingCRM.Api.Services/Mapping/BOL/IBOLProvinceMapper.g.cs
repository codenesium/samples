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
			ApiProvinceServerRequestModel model);

		ApiProvinceServerResponseModel MapBOToModel(
			BOProvince boProvince);

		List<ApiProvinceServerResponseModel> MapBOToModel(
			List<BOProvince> items);
	}
}

/*<Codenesium>
    <Hash>ad7ee2824a2fb6a98b1c44198f04335d</Hash>
</Codenesium>*/