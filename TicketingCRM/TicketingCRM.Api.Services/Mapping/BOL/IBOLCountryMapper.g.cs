using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLCountryMapper
	{
		BOCountry MapModelToBO(
			int id,
			ApiCountryServerRequestModel model);

		ApiCountryServerResponseModel MapBOToModel(
			BOCountry boCountry);

		List<ApiCountryServerResponseModel> MapBOToModel(
			List<BOCountry> items);
	}
}

/*<Codenesium>
    <Hash>8ea3cba98689de6b925b96ed074378b9</Hash>
</Codenesium>*/