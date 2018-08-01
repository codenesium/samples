using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLProvinceMapper
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
    <Hash>0500dfe76ad767d5e4dfca4b05ab56e1</Hash>
</Codenesium>*/