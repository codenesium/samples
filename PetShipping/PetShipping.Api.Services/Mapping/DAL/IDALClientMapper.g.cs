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
    <Hash>54b0251ea4b5aeb9644e2d1121017a84</Hash>
</Codenesium>*/