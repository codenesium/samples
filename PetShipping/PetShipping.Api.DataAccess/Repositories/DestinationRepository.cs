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
	public partial class DestinationRepository : AbstractDestinationRepository, IDestinationRepository
	{
		public DestinationRepository(
			ILogger<DestinationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73e72f48bd0ca1b8b944a1f1494eb008</Hash>
</Codenesium>*/