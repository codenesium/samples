using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALOtherTransportMapper
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
    <Hash>ef7a421f5019346a4c12dfc478a09801</Hash>
</Codenesium>*/