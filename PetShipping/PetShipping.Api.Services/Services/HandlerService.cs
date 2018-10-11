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
			IDALAirTransportMapper dalAirTransportMapper)
			: base(logger,
			       handlerRepository,
			       handlerModelValidator,
			       bolhandlerMapper,
			       dalhandlerMapper,
			       bolAirTransportMapper,
			       dalAirTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>22898a4e540648cf104f89eb0d116b22</Hash>
</Codenesium>*/