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
			ApiCountryRequestModel model);

		ApiCountryResponseModel MapBOToModel(
			BOCountry boCountry);

		List<ApiCountryResponseModel> MapBOToModel(
			List<BOCountry> items);
	}
}

/*<Codenesium>
    <Hash>1ba9b3a479256191546785370a5bf69c</Hash>
</Codenesium>*/