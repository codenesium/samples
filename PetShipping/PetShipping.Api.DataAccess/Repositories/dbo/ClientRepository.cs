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
	public class ClientRepository: AbstractClientRepository, IClientRepository
	{
		public ClientRepository(
			IDALClientMapper mapper,
			ILogger<ClientRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ab6f6d90f2743df5980be79a647d90cf</Hash>
</Codenesium>*/