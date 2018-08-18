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
	public partial class HandlerPipelineStepRepository : AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
	{
		public HandlerPipelineStepRepository(
			ILogger<HandlerPipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9b65e82f145dcc17caa889fe02d59c2b</Hash>
</Codenesium>*/