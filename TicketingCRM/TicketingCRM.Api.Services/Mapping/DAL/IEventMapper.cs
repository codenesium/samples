using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALEventMapper
	{
		Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapEntityToModel(
			Event item);

		List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items);
	}
}

/*<Codenesium>
    <Hash>09122f569bdd7f64d80d4168cd1f4631</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/