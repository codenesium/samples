using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class HandlerPipelineStepService : AbstractHandlerPipelineStepService, IHandlerPipelineStepService
	{
		public HandlerPipelineStepService(
			ILogger<IHandlerPipelineStepRepository> logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolhandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalhandlerPipelineStepMapper
			)
			: base(logger,
			       handlerPipelineStepRepository,
			       handlerPipelineStepModelValidator,
			       bolhandlerPipelineStepMapper,
			       dalhandlerPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a3e2be26eba1ebf03803c437d027a0e0</Hash>
</Codenesium>*/