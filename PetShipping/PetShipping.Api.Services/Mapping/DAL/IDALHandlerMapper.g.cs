using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALHandlerMapper
	{
		Handler MapBOToEF(
			BOHandler bo);

		BOHandler MapEFToBO(
			Handler efHandler);

		List<BOHandler> MapEFToBO(
			List<Handler> records);
	}
}

/*<Codenesium>
    <Hash>e9eaa6a51fbed8b67fbef1a6292e50b6</Hash>
</Codenesium>*/