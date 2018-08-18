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
    <Hash>cd5028b6a84f1b36d5fb1f1ff60191d8</Hash>
</Codenesium>*/