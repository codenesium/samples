using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALAirTransportMapper
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
    <Hash>f6f58fa99218a923a00756572dfc117a</Hash>
</Codenesium>*/