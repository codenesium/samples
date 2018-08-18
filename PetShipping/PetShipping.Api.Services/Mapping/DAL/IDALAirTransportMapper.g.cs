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
    <Hash>6e00b0210b61ec3728b823d59199e066</Hash>
</Codenesium>*/