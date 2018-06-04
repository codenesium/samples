using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class HandlerPipelineStepService: AbstractHandlerPipelineStepService, IHandlerPipelineStepService
	{
		public HandlerPipelineStepService(
			ILogger<HandlerPipelineStepRepository> logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper BOLhandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper DALhandlerPipelineStepMapper)
			: base(logger, handlerPipelineStepRepository,
			       handlerPipelineStepModelValidator,
			       BOLhandlerPipelineStepMapper,
			       DALhandlerPipelineStepMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>461404fca14b33bedb1e795d4ad7acef</Hash>
</Codenesium>*/