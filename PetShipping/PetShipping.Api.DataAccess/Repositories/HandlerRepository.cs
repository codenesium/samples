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
    <Hash>1e0aca82ea954d0227f92af38731dc28</Hash>
</Codenesium>*/