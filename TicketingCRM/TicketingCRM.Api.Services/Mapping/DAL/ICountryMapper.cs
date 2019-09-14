using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCountryMapper
	{
		Country MapModelToEntity(
			int id,
			ApiCountryServerRequestModel model);

		ApiCountryServerResponseModel MapEntityToModel(
			Country item);

		List<ApiCountryServerResponseModel> MapEntityToModel(
			List<Country> items);
	}
}

/*<Codenesium>
    <Hash>9890a18670aab31677b1c0b7e209ecb6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/