using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALAirTransportMapper
	{
		AirTransport MapBOToEF(
			BOAirTransport bo);

		BOAirTransport MapEFToBO(
			AirTransport efAirTransport);

		List<BOAirTransport> MapEFToBO(
			List<AirTransport> records);
	}
}

/*<Codenesium>
    <Hash>baf771d52e04f3ffa66ac4b43aa1fd4d</Hash>
</Codenesium>*/