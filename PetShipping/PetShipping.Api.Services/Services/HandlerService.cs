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
	public class HandlerService: AbstractHandlerService, IHandlerService
	{
		public HandlerService(
			ILogger<HandlerRepository> logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper BOLhandlerMapper,
			IDALHandlerMapper DALhandlerMapper)
			: base(logger, handlerRepository,
			       handlerModelValidator,
			       BOLhandlerMapper,
			       DALhandlerMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1db9ba86dfdec823ac75b37527236588</Hash>
</Codenesium>*/