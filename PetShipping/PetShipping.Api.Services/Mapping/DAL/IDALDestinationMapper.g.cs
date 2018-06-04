using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALDestinationMapper
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
    <Hash>e3be7c42b5fa60b2c1ecbe1887624801</Hash>
</Codenesium>*/