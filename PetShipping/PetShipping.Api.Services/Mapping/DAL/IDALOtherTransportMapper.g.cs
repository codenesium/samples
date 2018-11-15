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
    <Hash>c84c78407b59a60a50239e959dcaf677</Hash>
</Codenesium>*/