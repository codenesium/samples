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
    <Hash>bc7884b6f6db2fa1e825ca9efb5c1180</Hash>
</Codenesium>*/