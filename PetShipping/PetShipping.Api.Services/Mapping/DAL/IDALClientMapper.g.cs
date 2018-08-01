using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALClientMapper
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
    <Hash>10be9e642becd5a4866deedd2f16d24e</Hash>
</Codenesium>*/