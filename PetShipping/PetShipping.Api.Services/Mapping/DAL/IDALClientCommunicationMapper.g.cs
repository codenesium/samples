using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALClientCommunicationMapper
	{
		ClientCommunication MapBOToEF(
			BOClientCommunication bo);

		BOClientCommunication MapEFToBO(
			ClientCommunication efClientCommunication);

		List<BOClientCommunication> MapEFToBO(
			List<ClientCommunication> records);
	}
}

/*<Codenesium>
    <Hash>bf7aae2d4a9861b8fbcf381514c347a2</Hash>
</Codenesium>*/