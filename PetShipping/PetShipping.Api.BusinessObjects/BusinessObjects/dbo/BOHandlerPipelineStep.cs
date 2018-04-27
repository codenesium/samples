using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOHandlerPipelineStep: AbstractBOHandlerPipelineStep, IBOHandlerPipelineStep
	{
		public BOHandlerPipelineStep(
			ILogger<HandlerPipelineStepRepository> logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IHandlerPipelineStepModelValidator handlerPipelineStepModelValidator)
			: base(logger, handlerPipelineStepRepository, handlerPipelineStepModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>efda068be5ad81b9209ddfb612009317</Hash>
</Codenesium>*/