using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALClientMapper
	{
		Client MapBOToEF(
			BOClient bo);

		BOClient MapEFToBO(
			Client efClient);

		List<BOClient> MapEFToBO(
			List<Client> records);
	}
}

/*<Codenesium>
    <Hash>43e512ec93fefe7d7a2d4ca9d7c13c48</Hash>
</Codenesium>*/