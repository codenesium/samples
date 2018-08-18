using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>af69dc22935b527f657920e4dd1fd5e9</Hash>
</Codenesium>*/