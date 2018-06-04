using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>40a54a64bc82a9fd704070872b676564</Hash>
</Codenesium>*/