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
    <Hash>e60adca487ea9cebecf10a6b4cc87689</Hash>
</Codenesium>*/