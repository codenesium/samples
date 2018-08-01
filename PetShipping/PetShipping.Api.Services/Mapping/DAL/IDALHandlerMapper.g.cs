using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALHandlerMapper
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
    <Hash>9ffea33447d007d577b8622cebee69d7</Hash>
</Codenesium>*/