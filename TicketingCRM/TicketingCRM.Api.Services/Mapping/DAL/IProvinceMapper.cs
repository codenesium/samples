using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALProvinceMapper
	{
		Province MapModelToEntity(
			int id,
			ApiProvinceServerRequestModel model);

		ApiProvinceServerResponseModel MapEntityToModel(
			Province item);

		List<ApiProvinceServerResponseModel> MapEntityToModel(
			List<Province> items);
	}
}

/*<Codenesium>
    <Hash>a92ec84aaa6ef8ddfbe45e109f29cc7b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/