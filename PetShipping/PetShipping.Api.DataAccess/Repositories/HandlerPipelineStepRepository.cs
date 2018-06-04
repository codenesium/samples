using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class HandlerPipelineStepRepository: AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
	{
		public HandlerPipelineStepRepository(
			ILogger<HandlerPipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2d428d623b412a5e121de1cea23de83e</Hash>
</Codenesium>*/