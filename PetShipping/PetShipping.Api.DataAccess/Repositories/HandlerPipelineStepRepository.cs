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
    <Hash>940091a51d4d8763f78417304b3f88ff</Hash>
</Codenesium>*/