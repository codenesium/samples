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
			IApiHandlerPipelineStepModelValidator handlerPipelineStepModelValidator)
			: base(logger, handlerPipelineStepRepository, handlerPipelineStepModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6d441849908927f3ffa9b1ab435990fb</Hash>
</Codenesium>*/