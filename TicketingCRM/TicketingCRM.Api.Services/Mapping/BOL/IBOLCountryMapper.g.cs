using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLCountryMapper
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
    <Hash>e00f98327ce8897088deb120ce031f55</Hash>
</Codenesium>*/