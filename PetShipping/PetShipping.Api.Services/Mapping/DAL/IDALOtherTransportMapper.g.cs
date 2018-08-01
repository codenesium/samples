using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>61f08e36d957d631e6f8c3d34463774e</Hash>
</Codenesium>*/