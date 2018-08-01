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
	public partial class HandlerService : AbstractHandlerService, IHandlerService
	{
		public HandlerService(
			ILogger<IHandlerRepository> logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper bolhandlerMapper,
			IDALHandlerMapper dalhandlerMapper,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper
			)
			: base(logger,
			       handlerRepository,
			       handlerModelValidator,
			       bolhandlerMapper,
			       dalhandlerMapper,
			       bolAirTransportMapper,
			       dalAirTransportMapper,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>51c694a5eb41572edc884f3f74d98ad3</Hash>
</Codenesium>*/