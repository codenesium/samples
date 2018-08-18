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
    <Hash>c50714f4e52ab3727d9c314d4533ce7b</Hash>
</Codenesium>*/