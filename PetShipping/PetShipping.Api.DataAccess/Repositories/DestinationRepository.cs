using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>6aab0c92e673772c02aa201dc74c2f44</Hash>
</Codenesium>*/