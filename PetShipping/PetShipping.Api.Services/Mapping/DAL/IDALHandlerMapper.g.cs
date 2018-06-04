using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>da90e7ec6fdb5bd0c58a763faee0d15a</Hash>
</Codenesium>*/