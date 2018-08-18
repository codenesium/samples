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
	public partial class HandlerRepository : AbstractHandlerRepository, IHandlerRepository
	{
		public HandlerRepository(
			ILogger<HandlerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>47c9370ceab8f5e17c4c1679c75a4fc5</Hash>
</Codenesium>*/