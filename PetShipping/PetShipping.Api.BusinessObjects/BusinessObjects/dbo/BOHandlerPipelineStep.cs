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
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper handlerPipelineStepMapper)
			: base(logger, handlerPipelineStepRepository, handlerPipelineStepModelValidator, handlerPipelineStepMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>49483217abb0e50e3b5d24e70c7259ce</Hash>
</Codenesium>*/