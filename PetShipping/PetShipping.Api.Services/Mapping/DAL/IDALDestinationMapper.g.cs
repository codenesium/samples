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
    <Hash>134e6bf48b6a04398addf928b5d19cec</Hash>
</Codenesium>*/