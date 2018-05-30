using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class ClientCommunicationRepository: AbstractClientCommunicationRepository, IClientCommunicationRepository
	{
		public ClientCommunicationRepository(
			IDALClientCommunicationMapper mapper,
			ILogger<ClientCommunicationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fb5d2ceda893d09afb1629d880222a89</Hash>
</Codenesium>*/