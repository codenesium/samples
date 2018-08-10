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
    <Hash>1a2b23ab62c16a9252c351b8884cb258</Hash>
</Codenesium>*/