using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class ClientCommunicationRepository : AbstractClientCommunicationRepository, IClientCommunicationRepository
	{
		public ClientCommunicationRepository(
			ILogger<ClientCommunicationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5d511e699d948e416884b0143b61a881</Hash>
</Codenesium>*/