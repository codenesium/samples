using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALDestinationMapper
	{
		Destination MapBOToEF(
			BODestination bo);

		BODestination MapEFToBO(
			Destination efDestination);

		List<BODestination> MapEFToBO(
			List<Destination> records);
	}
}

/*<Codenesium>
    <Hash>343d47bfe805468108dcfc0a3540d63f</Hash>
</Codenesium>*/