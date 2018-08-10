using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALOtherTransportMapper
	{
		OtherTransport MapBOToEF(
			BOOtherTransport bo);

		BOOtherTransport MapEFToBO(
			OtherTransport efOtherTransport);

		List<BOOtherTransport> MapEFToBO(
			List<OtherTransport> records);
	}
}

/*<Codenesium>
    <Hash>3de98b45dc6a81210b07b34d5b0bc71f</Hash>
</Codenesium>*/