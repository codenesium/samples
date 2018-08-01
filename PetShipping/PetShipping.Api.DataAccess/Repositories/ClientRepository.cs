using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class ClientRepository : AbstractClientRepository, IClientRepository
	{
		public ClientRepository(
			ILogger<ClientRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>838352a0e4d0c334104a6203d63bcabf</Hash>
</Codenesium>*/